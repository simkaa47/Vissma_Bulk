namespace Core.Models.Plc
{
    public class PlcReadCommand
    {
        public int Start { get; set; }
        public int Count { get; set; }
        public ushort[] Buffer { get; set; }

        public Registers RegType { get; set; }

        public PlcReadCommand(int start, int count, ushort[] buffer, Registers regType)
        {
            Start = start;
            Count = count;
            Buffer = buffer;
            RegType = regType;
        }
        
    }  
    
}
