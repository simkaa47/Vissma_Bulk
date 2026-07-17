namespace Core.Models.Plc
{
    public class PlcButtonCommandModel
    {
        #region Произвести отбор 1
        public Parameter<bool> OtborCmd1 { get; } = new Parameter<bool>(nameof(OtborCmd1), "Произвести отбор 1", false, true, 9, 0);
        #endregion
        #region Произвести возврат 1
        public Parameter<bool> ReturnCmd1 { get; } = new Parameter<bool>(nameof(ReturnCmd1), "Произвести возврат 1", false, true, 200, 7);
        #endregion

        #region Набор воды

        public Parameter<bool> FloodOn { get; } = new Parameter<bool>(nameof(FloodOn), "Набор воды", false, true, 0, 1); // modbusRegNum, modbusBitNum нужно заполнить

        #endregion

        #region Произвести отбор 2
        public Parameter<bool> OtborCmd2 { get; } = new Parameter<bool>(nameof(OtborCmd2), "Произвести отбор 2", false, true, 146, 12);
        #endregion
        #region Произвести возврат 2
        public Parameter<bool> ReturnCmd2 { get; } = new Parameter<bool>(nameof(ReturnCmd2), "Произвести возврат 2", false, true, 200, 8);
        #endregion

        #region Запуск питателя
        public Parameter<bool> PitatelCmd { get; } = new Parameter<bool>(nameof(PitatelCmd), "Цикл питателя", false, true, 201, 0);
        #endregion
        #region Запуск дробилки
        public Parameter<bool> DrobilkaOn { get; } = new Parameter<bool>(nameof(DrobilkaOn), "Включить дробилку", false, true, 201, 5);
        #endregion

        #region Запуск вибратора 1
        public Parameter<bool> VibratorOnOff1 { get; } = new Parameter<bool>(nameof(VibratorOnOff1), "Запуск вибратора 1", false, true, 201, 2);
        #endregion
        #region Запуск вибратора 2
        public Parameter<bool> VibratorOnOff2 { get; } = new Parameter<bool>(nameof(VibratorOnOff2), "Запуск вибратора 2", false, true, 201, 3);
        #endregion
        #region Запуск вибратора 3
        public Parameter<bool> VibratorOnOff3 { get; } = new Parameter<bool>(nameof(VibratorOnOff3), "Запуск вибратора 3", false, true, 201, 4);
        #endregion

        #region Поднять верхний шибер
        public Parameter<bool> OpenHighShiberCmd { get; } = new Parameter<bool>(nameof(OpenHighShiberCmd), "Открыть верхний шибер", false, true, 200, 11);
        #endregion
        #region Закрыть верхний шибер
        public Parameter<bool> CloseHighShiberCmd { get; } = new Parameter<bool>(nameof(CloseHighShiberCmd), "Закрыть верхний шибер", false, true, 200, 12);
        #endregion
        #region Поднять нижний шибер
        public Parameter<bool> OpenLowShiberCmd { get; } = new Parameter<bool>(nameof(OpenLowShiberCmd), "Открыть нижний шибер", false, true, 200, 9);
        #endregion
        #region Закрыть нижний шибер
        public Parameter<bool> CloseLowShiberCmd { get; } = new Parameter<bool>(nameof(CloseLowShiberCmd), "Закрыть нижний шибер", false, true, 200, 10);
        #endregion
        #region Поднять барабан
        public Parameter<bool> UpBarabanCmd { get; } = new Parameter<bool>(nameof(UpBarabanCmd), "Поднять барабан", false, true, 200, 13);
        #endregion
        #region Опустить барабан
        public Parameter<bool> DownBarabanCmd { get; } = new Parameter<bool>(nameof(DownBarabanCmd), "Опустить барабан", false, true, 200, 14);
        #endregion

        #region Вращать барабан
        public Parameter<bool> RotateBarabanCmd { get; } = new Parameter<bool>(nameof(RotateBarabanCmd), "Вращать барабан", false, true, 201, 7);
        #endregion

        #region Запустить возврат проб
        public Parameter<bool> SysReturnCmd { get; } = new Parameter<bool>(nameof(SysReturnCmd), "Запустить транспортер", false, true, 201, 1);
        #endregion
        #region Запустить истиратель
        public Parameter<bool> IstiratelCmd { get; } = new Parameter<bool>(nameof(IstiratelCmd), "Запустить истиратель", false, true, 201, 6);
        #endregion

        #region Произвести калибровку накопителя
        public Parameter<bool> CalibrationNakopCmd { get; } = new Parameter<bool>(nameof(CalibrationNakopCmd), "Произвести калибровку накопителя", false, true, 200, 4);
        #endregion
        #region Поменять канистру накопителя
        public Parameter<bool> ChangeKanistraNakopCmd { get; } = new Parameter<bool>(nameof(ChangeKanistraNakopCmd), "Поменять канистру накопителя", false, true, 200, 1);
        #endregion
        #region Открыть замок накопителя
        public Parameter<bool> OpenLockNakopCmd { get; } = new Parameter<bool>(nameof(OpenLockNakopCmd), "Открыть замок накопителя", false, true, 200, 0);
        #endregion

        #region Сбросить ошибки
        public Parameter<bool> RstCmd { get; } = new Parameter<bool>(nameof(RstCmd), "Сброс ошибок", false, true, 9, 1);
        #endregion

        #region Синхронизироватб время
        public Parameter<bool> TimeSynchroCmd { get; } = new Parameter<bool>(nameof(TimeSynchroCmd), "Синхронизироватб время", false, true, 200, 3);
        #endregion

        #region Цикл блока сушки
        public Parameter<bool> DryCycleCmd { get; } = new Parameter<bool>(nameof(DryCycleCmd), "Цикл блока сушки", false, true, 200, 15);
        #endregion
    }
}
