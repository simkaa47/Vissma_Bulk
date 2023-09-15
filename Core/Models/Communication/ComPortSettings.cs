using CommunityToolkit.Mvvm.ComponentModel;
using Core.Infrastructure.DataAccess.Repositories;
using System.ComponentModel.DataAnnotations;
using System.IO.Ports;

namespace Core.Models.Communication
{
    public partial class ComPortSettings:EntityCommon
    {
        [Required]
        [ObservableProperty]
        public string _comPortName  = "COM1";
        [ObservableProperty]
        public int _baudrate  = 57600;
        [ObservableProperty]
        public Parity _parity; 

    }
}
