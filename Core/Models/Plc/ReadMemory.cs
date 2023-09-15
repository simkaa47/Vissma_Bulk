namespace Core.Models.Plc
{
    public class ReadMemory
    {
        public int Offset { get; set; }
        public ushort[] Buffer { get; set; } = null;
    }
}
