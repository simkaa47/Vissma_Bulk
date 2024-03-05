using CommunityToolkit.Mvvm.ComponentModel;
using Core.Models.AccesControl;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Events
{
    public partial class EventPoint : ObservableObject
    {
        public EventPoint(INotifyPropertyChanged describeObject, string? describePropertyName, object? describeValue)
        {
            _describeObject = describeObject;
            _describePropertyName = describePropertyName;
            _describeValue = describeValue;
            Describe();
        }

        private void Describe()
        {
            if (_describeObject is null || _describePropertyName is null || _describeValue is null) return;
            _describeObject.PropertyChanged += OnPropertyChangedValue;
        }

        private void OnPropertyChangedValue(object? sender, PropertyChangedEventArgs e)
        {
            var value = sender.GetType().GetProperty(_describePropertyName).GetValue(sender);
            if (value is null) return;
            IsActive = value.Equals(_describeValue);
            if (IsActive)
                LastDateTime = DateTime.Now;

        }
        #region Код события
        public string EventCode { get; set; } = string.Empty;
        #endregion

        #region Тип события
        [ObservableProperty]
        private EventType _type;
        #endregion

        #region Сообщение
        [ObservableProperty]
        private string? _message;
        #endregion

        #region Уровень доступа
        [ObservableProperty]
        public UserAccessLevel _level;
        #endregion

        #region Активность        
        private bool _isActive;
        [NotMapped]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
        #endregion

        #region Время срабатывания последнее
        [ObservableProperty]
        private DateTime _lastDateTime;
       
        #endregion

        private INotifyPropertyChanged? _describeObject;

        public string? _describePropertyName;

        public object? _describeValue;






    }
}
