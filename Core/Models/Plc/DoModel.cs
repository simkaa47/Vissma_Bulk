namespace Core.Models.Plc
{
    public class DoModel
    {
        #region Вибратор 1 - двигатель
        public Parameter<bool> VibratorM1 { get; } = new Parameter<bool>(nameof(VibratorM1), "Вибратор 1 - двигатель", false, true, 40960, 7) { IsOnlyRead = true, RegType = Registers.Hoilding };
        #endregion

        #region Вибратор 2 - двигатель
        public Parameter<bool> VibratorM2 { get; } = new Parameter<bool>(nameof(VibratorM2), "Вибратор 2 - двигатель", false, true, 40960, 8) { IsOnlyRead = true, RegType = Registers.Hoilding };
        #endregion

        #region Вибратор 3 - двигатель
        public Parameter<bool> VibratorM3 { get; } = new Parameter<bool>(nameof(VibratorM3), "Вибратор 3 - двигатель", false, true, 40960, 11) { IsOnlyRead = true, RegType = Registers.Hoilding };
        #endregion

        #region Сушка - двигатель верхнего шибера  - открытие
        public Parameter<bool> DryUnitHighMotorOpen { get; } = new Parameter<bool>(nameof(DryUnitHighMotorOpen), "Открытие верхнего шибера", false, true, 40962, 0) { IsOnlyRead = true, RegType = Registers.Hoilding };
        #endregion
        #region Сушка - двигатель верхнего шибера  - закрытие
        public Parameter<bool> DryUnitHighMotorClose { get; } = new Parameter<bool>(nameof(DryUnitHighMotorClose), "Закрытие верхнего шибера", false, true, 40962, 1) { IsOnlyRead = true, RegType = Registers.Hoilding };
        #endregion
        #region Сушка - двигатель нижнего шибера  - открытие
        public Parameter<bool> DryUnitLowMotorOpen { get; } = new Parameter<bool>(nameof(DryUnitLowMotorOpen), "Открытие нижнего шибера", false, true, 40962, 2) { IsOnlyRead = true, RegType = Registers.Hoilding };
        #endregion
        #region Сушка - двигатель верхнего шибера  - закрытие
        public Parameter<bool> DryUnitLowMotorClose { get; } = new Parameter<bool>(nameof(DryUnitLowMotorClose), "Закрытие нижнего шибера", false, true, 40962, 3) { IsOnlyRead = true, RegType = Registers.Hoilding };
        #endregion
        #region Сушка - двигатель опускания барабана
        public Parameter<bool> DryUnitLowBarabanMotor { get; } = new Parameter<bool>(nameof(DryUnitLowBarabanMotor), "Опускание барабана", false, true, 40962, 4) { IsOnlyRead = true, RegType = Registers.Hoilding };
        #endregion
        #region Сушка - двигатель поднятия барабана
        public Parameter<bool> DryUnitHighBarabanMotor { get; } = new Parameter<bool>(nameof(DryUnitHighBarabanMotor), "Поднятие барабана", false, true, 40962, 5) { IsOnlyRead = true, RegType = Registers.Hoilding };
        #endregion
    }
}
