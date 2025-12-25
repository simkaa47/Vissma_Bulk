namespace Core.Models.Plc
{
    public class DiModel
    {
        #region Проботборник 1 - аварийный датчик начального положения
        public Parameter<bool> SqProbHomeAbort1 { get; } = new Parameter<bool>(nameof(SqProbHomeAbort1), "Аварийный датчик начального положения", false, true, 32769, 0) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion
        #region Проботборник 1 - датчик начального положения
        public Parameter<bool> SqProbHome1 { get; } = new Parameter<bool>(nameof(SqProbHome1), "Датчик начального положения", false, true, 32769, 1) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion
        #region Проботборник 1 - аварийный датчик рабочего положения
        public Parameter<bool> SqProbWorkAbort1 { get; } = new Parameter<bool>(nameof(SqProbWorkAbort1), "Аварийный датчик рабочего положения", false, true, 32769, 2) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion
        #region Проботборник 1 - датчик рабочего положения
        public Parameter<bool> SqProbWork1 { get; } = new Parameter<bool>(nameof(SqProbWork1), "Датчик рабочего положения", false, true, 32769, 3) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion

        #region Проботборник 2 - аварийный датчик начального положения
        public Parameter<bool> SqProbHomeAbort2 { get; } = new Parameter<bool>(nameof(SqProbHomeAbort2), "Аварийный датчик начального положения", false, true, 32769, 8) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion
        #region Проботборник 2 - датчик начального положения
        public Parameter<bool> SqProbHome2 { get; } = new Parameter<bool>(nameof(SqProbHome2), "Датчик начального положения", false, true, 32769, 9) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion
        #region Проботборник 2 - аварийный датчик рабочего положения
        public Parameter<bool> SqProbWorkAbort2 { get; } = new Parameter<bool>(nameof(SqProbWorkAbort2), "Аварийный датчик рабочего положения", false, true, 32769, 10) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion
        #region Проботборник 2 - датчик рабочего положения
        public Parameter<bool> SqProbWork2 { get; } = new Parameter<bool>(nameof(SqProbWork2), "Датчик рабочего положения", false, true, 32769, 11) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion


        #region Сушка  - верхний шибер открыт
        public Parameter<bool> SqDryHighShiberOpened { get; } = new Parameter<bool>(nameof(SqDryHighShiberOpened), "Верхний шибер открыт", false, true, 32768, 8) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion
        #region Сушка  - верхний шибер закрыт
        public Parameter<bool> SqDryHighShiberClosed { get; } = new Parameter<bool>(nameof(SqDryHighShiberClosed), "Верхний шибер закрыт", false, true, 32768, 9) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion
        #region Сушка  - нижний шибер открыт
        public Parameter<bool> SqDryLowShiberOpened { get; } = new Parameter<bool>(nameof(SqDryLowShiberOpened), "Нижний шибер открыт", false, true, 32768, 10) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion
        #region Сушка  - нижний шибер закрыт
        public Parameter<bool> SqDryLowShiberClosed { get; } = new Parameter<bool>(nameof(SqDryLowShiberClosed), "Нижний шибер закрыт", false, true, 32768, 11) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion
        #region Сушка  - барабан внизу
        public Parameter<bool> SqBarabanLowPosition { get; } = new Parameter<bool>(nameof(SqBarabanLowPosition), "Барабан внизу", false, true, 32768, 12) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion
        #region Сушка  - барабан вверху
        public Parameter<bool> SqBarabanHighPosition { get; } = new Parameter<bool>(nameof(SqBarabanHighPosition), "Барабан вверху", false, true, 32768, 13) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion

        #region Накопитель - датчик двери
        public Parameter<bool> SqDoorNakopitel { get; } = new Parameter<bool>(nameof(SqDoorNakopitel), "Датчик двери", false, true, 32770, 11) { IsOnlyRead = true, RegType = Registers.Input, Value = true };
        #endregion
        #region Накопитель - датчик полного оборота
        public Parameter<bool> SqNakopFullRev { get; } = new Parameter<bool>(nameof(SqNakopFullRev), "Датчик полного оборота", false, true, 32770, 9) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion
        #region Накопитель - датчик ячейки
        public Parameter<bool> SqNakopCell { get; } = new Parameter<bool>(nameof(SqNakopCell), "Датчик ячейки", false, true, 32770, 8) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion
        #region Накопитель - датчик канистры
        public Parameter<bool> SqNakopKanistra { get; } = new Parameter<bool>(nameof(SqNakopKanistra), "Датчик канистры", false, true, 32770, 10) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion
        
        #region Шибер - сушка выключена
        public Parameter<bool> SqDryValveOff { get; } = 
            new Parameter<bool>(nameof(SqDryValveOff), "Шибер - сушка выключена", false, true, 32771, 9){ IsOnlyRead = true, RegType = Registers.Input };

        #endregion
        
        #region Шибер - сушка выключена
        public Parameter<bool> SqDryValveOn { get; } = 
            new Parameter<bool>(nameof(SqDryValveOn), "Шибер - сушка включена", false, true, 32771, 10){ IsOnlyRead = true, RegType = Registers.Input };

        #endregion
        
        
    }
}

