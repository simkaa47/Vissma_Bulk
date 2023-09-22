namespace Core.Models.Plc
{
    public class PlcIndicationModel
    {
        #region Статус накопителя
        public Parameter<short> NakopitelStatus { get; } = new Parameter<short>(nameof(NakopitelStatus), "Статус накопителя", 0, 100, 0, 0) { IsOnlyRead = true};
        #endregion
        #region Канистры накопителя
        public List<Kanistra> Kanistras { get; } = Enumerable.Range(0, 8).Select(i => new Kanistra(i)).ToList();
        #endregion
        #region Номер текущей ячейки накопителя
        public Parameter<short> NakopitelCurrentCell { get; } = new Parameter<short>(nameof(NakopitelCurrentCell), "Номер текущей ячейки накопителя", 1, 8, 145, 0) { IsOnlyRead = true };
        #endregion
        #region Готовность накопителя
        public Parameter<bool> NakopitelReady { get; } = new Parameter<bool>(nameof(NakopitelReady), "Готовность накопителя", false, true, 146, 0) { IsOnlyRead = true };
        #endregion
        #region Накопитель занят
        public Parameter<bool> NakopitelBusy { get; } = new Parameter<bool>(nameof(NakopitelBusy), "Накопитель занят", false, true, 146, 1) { IsOnlyRead = true };
        #endregion
        #region Готовность первичного проботборника
        public Parameter<bool> ProbotborReady1 { get; } = new Parameter<bool>(nameof(ProbotborReady1), "Готовность к отбору", false, true, 146, 2) { IsOnlyRead = true };
        #endregion
        #region Первичный проботборник занят
        public Parameter<bool> ProbotborBusy1 { get; } = new Parameter<bool>(nameof(ProbotborBusy1), "Занят", false, true, 146, 3) { IsOnlyRead = true };
        #endregion
        #region Готовность вторичного проботборника
        public Parameter<bool> ProbotborReady2 { get; } = new Parameter<bool>(nameof(ProbotborReady2), "Готовность к отбору", false, true, 146, 4) { IsOnlyRead = true };
        #endregion
        #region Вторичный проботборник занят
        public Parameter<bool> ProbotborBusy2 { get; } = new Parameter<bool>(nameof(ProbotborBusy2), "Занят", false, true, 146, 5) { IsOnlyRead = true };
        #endregion
        #region Готовность блока предварительной сушки
        public Parameter<bool> DryUnitReady { get; } = new Parameter<bool>(nameof(ProbotborReady1), "Готовность блока предварительной сушки", false, true, 146, 6) { IsOnlyRead = true };
        #endregion
        #region Блок предварительной сушки занят
        public Parameter<bool> DryUnitBusy { get; } = new Parameter<bool>(nameof(DryUnitBusy), "Блок предварительной сушки занят", false, true, 146, 7) { IsOnlyRead = true };
        #endregion
        #region Готовность питателя
        public Parameter<bool> PitatelReady { get; } = new Parameter<bool>(nameof(PitatelReady), "Готовность питателя", false, true, 146, 8) { IsOnlyRead = true };
        #endregion
        #region Питатель занят
        public Parameter<bool> PitatelBusy { get; } = new Parameter<bool>(nameof(PitatelBusy), "Питатель занят", false, true, 146, 9) { IsOnlyRead = true };
        #endregion
        #region Готовность возврата проб
        public Parameter<bool> SysReturnReady { get; } = new Parameter<bool>(nameof(SysReturnReady), "Готовность возврата проб", false, true, 146, 10) { IsOnlyRead = true };
        #endregion
        #region Система возврата проб занята
        public Parameter<bool> SysReturnBusy { get; } = new Parameter<bool>(nameof(SysReturnBusy), "Система возврата проб занята", false, true, 146, 11) { IsOnlyRead = true };
        #endregion
        #region Цикл делителя
        public Parameter<bool> DelitelCycle { get; } = new Parameter<bool>(nameof(DelitelCycle), "Цикл делителя", false, true, 146, 12) { IsOnlyRead = true };
        #endregion
        #region Общая готовность
        public Parameter<bool> CommonReady { get; } = new Parameter<bool>(nameof(CommonReady), "Общая готовность", false, true, 146, 13) { IsOnlyRead = true };
        #endregion
        #region Наличие ошибок
        public Parameter<bool> GlobalError { get; } = new Parameter<bool>(nameof(GlobalError), "Наличие ошибок", false, true, 146, 15) { IsOnlyRead = true };
        #endregion
        #region Статус первичного проботборника
        public Parameter<short> ProbotborStatus1 { get; } = new Parameter<short>(nameof(ProbotborStatus1), "Статус первичного проботборника", 0, 100, 147, 0) { IsOnlyRead = true };
        #endregion
        #region Статус вторичного проботборника
        public Parameter<short> ProbotborStatus2 { get; } = new Parameter<short>(nameof(ProbotborStatus2), "Статус вторичного проботборника", 0, 100, 148, 0) { IsOnlyRead = true };
        #endregion
        #region Статус питателя
        public Parameter<short> PitatelStatus { get; } = new Parameter<short>(nameof(PitatelStatus), "Статус питателя", 0, 100, 152, 0) { IsOnlyRead = true };
        #endregion
        #region Статус блока предварительной сушки
        public Parameter<short> DryUnitStatus { get; } = new Parameter<short>(nameof(DryUnitStatus), "Статус блока предварительной сушки", 0, 100, 151, 0) { IsOnlyRead = true };
        #endregion
        #region Статус системы возврата проб
        public Parameter<short> SysReturnStatus { get; } = new Parameter<short>(nameof(SysReturnStatus), "Статус системы возврата проб", 0, 100, 153, 0) { IsOnlyRead = true };
        #endregion
        #region Текущая влажность, %
        public Parameter<float> CurrentHumm { get; } = new Parameter<float>(nameof(CurrentHumm), "Текущая влажность, %", 0, 100, 154, 0) { IsOnlyRead = true };
        #endregion
        #region Текущая температура в блоке сушки, C
        public Parameter<float> DryUnitCurrentTemperature  { get; } = new Parameter<float>(nameof(DryUnitCurrentTemperature), "Текущая температура в блоке сушки, C", 0, 100, 156, 0) { IsOnlyRead = true };
        #endregion
        #region Статус первичной дробилки
        public Parameter<short> DrobilkaStatus { get; } = new Parameter<short>(nameof(DrobilkaStatus), "Статус первичной дробилки", 0, 100, 158, 0) { IsOnlyRead = true };
        #endregion
        #region Статус истирателя
        public Parameter<short> IstiratelStatus { get; } = new Parameter<short>(nameof(IstiratelStatus), "Статус истирателя", 0, 100, 159, 0) { IsOnlyRead = true };
        #endregion
        #region Текущее время делителя, с
        public Parameter<short> DelitelTimeCurrent { get; } = new Parameter<short>(nameof(DelitelTimeCurrent), "Текущее время делителя, с", 0, short.MaxValue, 163, 0) { IsOnlyRead = true };
        #endregion
        #region Время до следующего отбора, часов
        public Parameter<short> TimeBeforeNextOtborHours { get; } = new Parameter<short>(nameof(TimeBeforeNextOtborHours), "Время до следующего отбора, часов", 0, 23, 160, 0) { IsOnlyRead = true };
        #endregion
        #region Время до следующего отбора, минут
        public Parameter<short> TimeBeforeNextOtborMinutes { get; } = new Parameter<short>(nameof(TimeBeforeNextOtborMinutes), "Время до следующего отбора, минут", 0, 59, 161, 0) { IsOnlyRead = true };
        #endregion
        #region Время до следующего отбора, секунды
        public Parameter<short> TimeBeforeNextOtborSeconds { get; } = new Parameter<short>(nameof(TimeBeforeNextOtborSeconds), "Время до следующего отбора, секунды", 0, 59, 162, 0) { IsOnlyRead = true };
        #endregion
        #region Статус цикла отбора
        public Parameter<ushort> MainProcessStatus { get; } = new Parameter<ushort>(nameof(MainProcessStatus), "Статус автоматиченского отбора", 0, 10, 180, 0);
        #endregion

        #region Текущее время ПЛК, год
        public Parameter<short> CurrentPlcTimeYear { get; } = new Parameter<short>(nameof(CurrentPlcTimeYear), "Текущее время ПЛК, год", 0, 99, 49543, 0) { IsOnlyRead = true };
        #endregion

        #region Текущее время ПЛК, месяц
        public Parameter<short> CurrentPlcTimeMonth { get; } = new Parameter<short>(nameof(CurrentPlcTimeMonth), "Текущее время ПЛК, месяц", 1, 12, 49544, 0) { IsOnlyRead = true };
        #endregion

        #region Текущее время ПЛК, день
        public Parameter<short> CurrentPlcTimeDay { get; } = new Parameter<short>(nameof(CurrentPlcTimeDay), "Текущее время ПЛК, день", 1, 31, 49545, 0) { IsOnlyRead = true };
        #endregion
        #region Текущее время ПЛК, час
        public Parameter<short> CurrentPlcTimeHour { get; } = new Parameter<short>(nameof(CurrentPlcTimeHour), "Текущее время ПЛК, час", 0, 24, 49546, 0) { IsOnlyRead = true };
        #endregion

        #region Текущее время ПЛК, минута
        public Parameter<short> CurrentPlcTimeMinute { get; } = new Parameter<short>(nameof(CurrentPlcTimeMinute), "Текущее время ПЛК, минута", 0, 59, 49547, 0) { IsOnlyRead = true };
        #endregion

        #region Текущее время ПЛК, секунда
        public Parameter<short> CurrentPlcTimeSecond { get; } = new Parameter<short>(nameof(CurrentPlcTimeSecond), "Текущее время ПЛК, секунда", 0, 59, 49548, 0) { IsOnlyRead = true };
        #endregion

        #region Текущее время питателя, с
        public Parameter<short> PitatelTimeCurrent { get; } = new Parameter<short>(nameof(PitatelTimeCurrent), "Текущее время питателя, с, с", 0, short.MaxValue, 179, 0) { IsOnlyRead = true };
        #endregion

        #region Текущее время истирателя, с
        public Parameter<short> IstiratelTimeCurrent { get; } = new Parameter<short>(nameof(IstiratelTimeCurrent), "Текущее время истирателя, с, с", 0, short.MaxValue, 178, 0) { IsOnlyRead = true };
        #endregion

        #region Текущее время системы возврата проб, с
        public Parameter<short> SysReturnTimeCurrent { get; } = new Parameter<short>(nameof(SysReturnTimeCurrent), "Текущее время системы возврата проб, с", 0, short.MaxValue, 181, 0) { IsOnlyRead = true };
        #endregion


    }
}
