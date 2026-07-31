using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Models.Plc;
using Core.Services.Plc;
using Microsoft.Extensions.Logging;

namespace Core.ViewModels
{
    public partial class PlcViewModel:ViewModelBase
    {
        private readonly ILogger _logger;

        public PlcViewModel(PlcMainService plcMainService, ILogger<PlcViewModel> logger)
        {
            PlcMainService = plcMainService;
            _logger = logger;
            PlcMainService.LogEvent += Log;
            DescribeForChangeControlPages();
        }

        [ObservableProperty]

        private bool _isFlooding = false;

        [ObservableProperty]
        private bool _controlPageSecond;

        public PlcMainService PlcMainService { get; }

        private void Log(string message)
        {
            _logger.LogInformation($"Сервис коммуникации с ПЛК: {message}");

        }
        [RelayCommand]
        public async void SavePlcConnectSettings()
        {
            await PlcMainService.SaveConnectSettingsAsync();
        }
        [RelayCommand]
        public void WriteParameter(object parameter)
        {
            if(parameter is Parameter<bool> parBool)
            {
                parBool.WriteValue = !parBool.Value;
            }
            PlcMainService.WriteParameter(parameter);

        }

        [RelayCommand]
        private void ChangeControlPage()
        {
            ControlPageSecond = !ControlPageSecond;
        }


        private void DescribeForChangeControlPages()
        {
            PlcMainService.PlcModel.Indication.ProbotborStatus1.PropertyChanged += (s, args) => ControlPageSecond = false;
            //PlcMainService.PlcModel.Indication.PitatelStatus.PropertyChanged += (s, args) => ControlPageSecond = false;
            //PlcMainService.PlcModel.Indication.DrobilkaStatus.PropertyChanged += (s, args) => ControlPageSecond = false;
            //PlcMainService.PlcModel.Indication.ProbotborStatus2.PropertyChanged += (s, args) => ControlPageSecond = false;
            //
            //PlcMainService.PlcModel.Indication.DryUnitStatus.PropertyChanged += (s, args) => ControlPageSecond = true;
            //PlcMainService.PlcModel.Indication.IstiratelStatus.PropertyChanged += (s, args) => ControlPageSecond = true;
            PlcMainService.PlcModel.Indication.NakopitelStatus.PropertyChanged += (s, args) => ControlPageSecond = true;
            //PlcMainService.PlcModel.Indication.SysReturnStatus.PropertyChanged += (s, args) => ControlPageSecond = true;
        }

        [RelayCommand]
        public async void RunFlooding(object parameter)
        {
            if (IsFlooding)
            {
                WriteParameter(parameter);
            }
            
        }
    }
}
