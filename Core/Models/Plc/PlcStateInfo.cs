using CommunityToolkit.Mvvm.ComponentModel;

namespace Core.Models.Plc
{
    public partial class PlcStateInfo:ObservableObject
    {
        [ObservableProperty]
        private bool _connected;
    }
}
