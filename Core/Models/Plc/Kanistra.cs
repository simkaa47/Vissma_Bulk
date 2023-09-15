namespace Core.Models.Plc
{
    public class Kanistra
    {
        public Kanistra(int index)
        {
            Index = index;
            Id.Id += index;
            Id.ModbusRegNum = 1+index*9;
            ProbeCnt.Id += index;
            ProbeCnt.ModbusRegNum = 8 + index * 9;
            IsExist.Id += index;
            IsExist.ModbusRegNum = 9 + index * 9;
        }
        public int Index { get;  }

        public Parameter<string> Id { get; set; } = new Parameter<string>("KanistraId", "Id канистры", string.Empty, "ZZZZZZZZZZZZZZZZ", 1, 0) {Length = 12 };
        public Parameter<short> ProbeCnt { get; } = new Parameter<short>("ProbeCnt", "Кол-во проб в канистре", 0, short.MaxValue, 8, 0);
        public Parameter<bool> IsExist { get; } = new Parameter<bool>("KanistraExist", "Наличие канистры", false, true, 9, 0);
    }
}
