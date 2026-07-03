using Core.Models.Communication;
using Core.Models.Plc;

namespace Core.Services.Plc
{
    public static class PlcDataFactory
    {
        public static IEnumerable<PlcConnectSettings> GetConnectSettings() 
        {
            return new List<PlcConnectSettings>
            {
                new PlcConnectSettings
                {
                    ScanFrequence = 100,
                    EthernetSettings = new EthernetSettings
                    {
                        Ip = "127.0.0.1",
                        Port = 503
                    }
                }
            };
        
        }
    }
}
