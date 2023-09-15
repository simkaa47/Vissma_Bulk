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
        }        

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
    }
}
