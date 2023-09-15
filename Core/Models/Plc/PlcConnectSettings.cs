using CommunityToolkit.Mvvm.ComponentModel;
using Core.Infrastructure.DataAccess.Repositories;
using Core.Models.Communication;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Plc
{
    public partial class PlcConnectSettings:EntityCommon
    {
        public virtual EthernetSettings? EthernetSettings { get; set; }
        [ObservableProperty]
        [Range(100,1000)]
        private int _scanFrequence;
    }
}
