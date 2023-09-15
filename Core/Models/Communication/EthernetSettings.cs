using CommunityToolkit.Mvvm.ComponentModel;
using Core.Infrastructure.DataAccess.Repositories;
using Core.Infrastructure.Validators;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Communication
{
    public partial class EthernetSettings:EntityCommon
    {
        [IsIpAddress(ErrorMessage = "Incorrect IP string!")]
        [ObservableProperty]
        private string _ip = "192.168.1.122";
        [ObservableProperty]
        private int _port;
        [ObservableProperty]
        [Range(100,1000)]
        private int _receiveTimeout = 1000;
        [ObservableProperty]
        [Range(100, 1000)]
        private int _sendTimeout = 1000;
    }
}
