using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections;
using System.ComponentModel;
using System.Timers;

namespace Core.Models.Plc
{
    public partial class Parameter<T> : ObservableObject, INotifyDataErrorInfo where T : IComparable
    {
        public Parameter(string id, string description, T minValue, T maxValue, int modbusRegNum, int modbusBitNum)
        {
            Id = id;
            Description = description;
            MinValue = minValue;
            MaxValue = maxValue;
            ModbusRegNum = modbusRegNum;
            ModbusBitNum = modbusBitNum;
            timer = new System.Timers.Timer(5000);
            timer.Elapsed += OnTimerElapsed;
            PlcModel.Parameters.Add(this);
        }
        [ObservableProperty]
        private Registers _regType;


        [ObservableProperty]
        private bool _isOnlyRead;

        [ObservableProperty]
        private bool _validationOk;

        [ObservableProperty]
        private int _length;

        [ObservableProperty]
        private string _advice = "";


        public string Id { get; set; }
        public bool IsReadOnly { get; }

        [ObservableProperty]
        public string? _description;

        [ObservableProperty]
        public int _modbusRegNum;

        [ObservableProperty]
        public int _modbusBitNum;

        [ObservableProperty]
        private bool _isWriting;

        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                if (SetProperty(ref _value, value))
                    WriteValue = value;
                IsWriting = false;
            }
        }

        T _writeValue;

        public T WriteValue
        {
            get => _writeValue;
            set
            {
                if (value != null)
                {
                    ValidationOk = true;
                    ClearError(nameof(WriteValue));
                    if (value.CompareTo(MinValue) < 0 || value.CompareTo(MaxValue) > 0)
                    {
                        AddError(nameof(WriteValue), $"Input value ({value}) must be between {MinValue} and {MaxValue}");
                    }
                    if (value.CompareTo(Value) != 0)
                    {
                        RestartTimer();
                    }
                    SetProperty(ref _writeValue, value);

                }
            }
        }

        [ObservableProperty]
        private T _minValue;

        [ObservableProperty]
        private T _maxValue;

        #region Таймер
        System.Timers.Timer timer;


        void RestartTimer()
        {
            if (timer.Enabled) timer.Stop();
            timer.Start();
        }

        void OnTimerElapsed(object source, ElapsedEventArgs e)
        {
            timer.Stop();
            WriteValue = Value;
        }


        #endregion

        private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();
        public bool HasErrors => _propertyErrors.Any();
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            return _propertyErrors.GetValueOrDefault(propertyName, null);
        }

        public void AddError(string propertyName, string message)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, new List<string>());
            }
            _propertyErrors[propertyName].Add(message);
            OnPropertyChanged(propertyName);
            ValidationOk = false;
        }

        public void ClearError(string propertyName)
        {
            if (_propertyErrors.Remove(propertyName))
            {
                OnErrorsChanged(propertyName);
            }
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}

