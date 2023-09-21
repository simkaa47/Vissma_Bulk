using Core.Models.Plc;
using Core.Services.Communication;
using Core.ViewModels;
using System.Text;

namespace Core.Services.Plc
{
    public static class GetModbusCommandService
    {
        public static bool initialized;
        public static ReadMemory holdingReadMemory = new ReadMemory();
        public static ReadMemory inputReadMemory = new ReadMemory();
        public static List<PlcReadCommand> commands = new List<PlcReadCommand>();

        private static void Init()
        {
            InitByType(Registers.Hoilding, holdingReadMemory);
            InitByType(Registers.Input, inputReadMemory);
            initialized = true;
        }

        private static void InitByType(Registers regType, ReadMemory readMemory)
        {
            var sequences = GetParameterSequences(regType).OrderBy(s => s.Start).ToList();
            if (sequences.Count == 0) return;
            var min = sequences.First().Start;
            var max = sequences.Select(s => s.End).Max();
            readMemory.Offset = min;
            readMemory.Buffer = new ushort[max - min + 1];
            int i = min;            
            do
            {
                var belongeds = GetBelongedSequences(new ParameterSequence(i, i + 99), sequences);
                if (belongeds.Count == 0)
                {
                    i = i + 100;
                    continue;
                }
                else
                {
                    var points = belongeds.SelectMany(b => new int[] { b.Start, b.End }).ToList();
                    var minPoint = Math.Max(points.Min(), i);
                    var maxPoint = Math.Min(points.Max(), i + 99);
                    var count = maxPoint - minPoint + 1;
                    commands.Add(new PlcReadCommand(minPoint, count, readMemory.Buffer, regType));
                    i = maxPoint + 1;
                }
            } while (i < max);

        }

        public static void ScanInfoFromPlc(PlcModel plc, ModbusCommunicationService? comService)
        {
            if (!initialized)
            {
                Init();
            }
            foreach (var command in commands)
            {
                if (command.RegType == Registers.Hoilding)
                {
                    var regs = comService.ReadHoldingRegisters(command.Start, command.Count);
                    regs.CopyTo(0, holdingReadMemory.Buffer, command.Start - holdingReadMemory.Offset, regs.Count);
                }
                else
                {
                    var regs = comService.ReadReadingRegisters(command.Start, command.Count);
                    regs.CopyTo(0, inputReadMemory.Buffer, command.Start - inputReadMemory.Offset, regs.Count);
                }

            }
            GetValuesForParameters();
        }

        private static List<ParameterSequence> GetParameterSequences(Registers regType)
        {
            var list = new List<ParameterSequence>();
            foreach (var par in PlcModel.Parameters)
            {
                if (par is Parameter<ushort> parUshort && parUshort.RegType == regType)
                    list.Add(new ParameterSequence(parUshort.ModbusRegNum, parUshort.ModbusRegNum));
                else if (par is Parameter<short> parShort && parShort.RegType == regType)
                    list.Add(new ParameterSequence(parShort.ModbusRegNum, parShort.ModbusRegNum));
                else if (par is Parameter<bool> parBool && parBool.RegType == regType)
                    list.Add(new ParameterSequence(parBool.ModbusRegNum, parBool.ModbusRegNum));
                else if (par is Parameter<int> parInt && parInt.RegType == regType)
                    list.Add(new ParameterSequence(parInt.ModbusRegNum, parInt.ModbusRegNum + 1));
                else if (par is Parameter<uint> parUint && parUint.RegType == regType)
                    list.Add(new ParameterSequence(parUint.ModbusRegNum, parUint.ModbusRegNum + 1));
                else if (par is Parameter<float> parFloat && parFloat.RegType == regType)
                    list.Add(new ParameterSequence(parFloat.ModbusRegNum, parFloat.ModbusRegNum + 1));
                else if (par is Parameter<string> parstring && parstring.RegType == regType)
                {
                    var regs = parstring.Length % 2 != 0 ? parstring.Length / 2 + 1 : parstring.Length / 2;
                    list.Add(new ParameterSequence(parstring.ModbusRegNum, parstring.ModbusRegNum + regs - 1));
                }

            }
            return list;
        }


        private static List<ParameterSequence> GetBelongedSequences(ParameterSequence diapasone, IEnumerable<ParameterSequence> sequences)
        {
            var list = new List<ParameterSequence>();
            list = sequences.Where(s => IsBelongToSequence(diapasone, s)).ToList();
            return list;
        }

        private static bool IsBelongToSequence(ParameterSequence diapasone, ParameterSequence sequence)
        {
            return (sequence.Start >= diapasone.Start && sequence.Start <= diapasone.End) ||
                (sequence.End >= diapasone.Start && sequence.End <= diapasone.End) ||
                (sequence.Start < diapasone.Start && sequence.End > diapasone.End);
        }

        private static void GetValuesForParameters()
        {
            foreach (var par in PlcModel.Parameters)
            {
                if (par is Parameter<ushort> parUshort)
                {
                    var memory = parUshort.RegType == Registers.Hoilding ? holdingReadMemory : inputReadMemory;
                    parUshort.Value = memory.Buffer[parUshort.ModbusRegNum - memory.Offset];
                }
                else if (par is Parameter<short> parShort)
                {
                    var memory = parShort.RegType == Registers.Hoilding ? holdingReadMemory : inputReadMemory;
                    var bytes = BitConverter.GetBytes(memory.Buffer[parShort.ModbusRegNum - memory.Offset]);
                    parShort.Value = BitConverter.ToInt16(bytes);
                }
                else if (par is Parameter<bool> parBool)
                {
                    var memory = parBool.RegType == Registers.Hoilding ? holdingReadMemory : inputReadMemory;
                    parBool.Value = (memory.Buffer[parBool.ModbusRegNum - memory.Offset] & (ushort)Math.Pow(2, parBool.ModbusBitNum)) > 0;
                }
                else if (par is Parameter<int> parInt)
                {
                    var memory = parInt.RegType == Registers.Hoilding ? holdingReadMemory : inputReadMemory;
                    var bytes = BitConverter.GetBytes(memory.Buffer[parInt.ModbusRegNum - memory.Offset]);
                    parInt.Value = BitConverter.ToInt32(bytes);
                }
                else if (par is Parameter<uint> parUint)
                {
                    var memory = parUint.RegType == Registers.Hoilding ? holdingReadMemory : inputReadMemory;
                    var bytes = BitConverter.GetBytes(memory.Buffer[parUint.ModbusRegNum - memory.Offset]);
                    parUint.Value = BitConverter.ToUInt32(bytes);
                }
                else if (par is Parameter<float> parFloat)
                {
                    var memory = parFloat.RegType == Registers.Hoilding ? holdingReadMemory : inputReadMemory;
                    var bytes = memory.Buffer.Skip(parFloat.ModbusRegNum - memory.Offset).Take(2).SelectMany(s => BitConverter.GetBytes(s)).ToArray();
                    parFloat.Value = BitConverter.ToSingle(bytes);
                }
                else if (par is Parameter<string> parstring)
                {
                    var memory = parstring.RegType == Registers.Hoilding ? holdingReadMemory : inputReadMemory;
                    var regs = parstring.Length % 2 != 0 ? parstring.Length / 2 + 1 : parstring.Length / 2;
                    var bytes = memory.Buffer
                        .Skip(parstring.ModbusRegNum - memory.Offset)
                        .Take(regs)
                        .SelectMany(s => BitConverter.GetBytes(s))
                        .TakeWhile(b=>b>0)
                        .ToArray();
                    parstring.Value = Encoding.ASCII.GetString(bytes).Replace("\0","");
                }
            }
        }    

    }
}
