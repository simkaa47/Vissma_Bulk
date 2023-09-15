namespace Core.Models.Plc
{
    public class PlcSettingsModel
    {
        #region Уставка проб в канистру, шт
        public Parameter<ushort> KanistraSv { get; } = new Parameter<ushort>(nameof(KanistraSv), "Уставка проб в канистру, шт", 1, 20, 20000, 0);
        #endregion
        #region Канстр в накопителе, шт
        public Parameter<short> NakopitelVolume { get; } = new Parameter<short>(nameof(NakopitelVolume), "Обьем накопителя, канистр", 1, 16, 20001, 0);
        #endregion
        #region Время сбора в одну канистру, мин
        public Parameter<ushort> TimeForKanistra { get; } = new Parameter<ushort>(nameof(TimeForKanistra), "Время сбора в одну канистру, мин", 4, 1440, 20002, 0);
        #endregion
        #region Id пробы
        public Parameter<string> ProbeId { get; } = new Parameter<string>(nameof(ProbeId), "Id пробы", string.Empty, "ZZZZZZZZZZZZZ", 20003, 0) { Length = 12, IsOnlyRead=true };
        #endregion
        #region Автоматичекий режим
        public Parameter<bool> AutoMode { get; } = new Parameter<bool>(nameof(AutoMode), "Автоматичекий режим", false, true, 20010, 0);
        #endregion
        #region Скорости ПЧ
        public List<Parameter<short>> FcFrequencesSvs { get; } = Enumerable.Range(0, 4).Select(i => new Parameter<short>(nameof(FcFrequencesSvs) + i + 1, $"Скорость ПЧ {i + 1}, Гц", 0, 50, 20011 + i, 0)).ToList();
        #endregion
        #region Блок осушителя - задержка перед закртием шиберов
        public Parameter<short> DryUnitDelayClose { get; } = new Parameter<short>(nameof(DryUnitDelayClose), "Блок осушителя - задержка перед закрытием шиберов, с", 0, 10, 20015, 0);
        #endregion
        #region Блок осушителя - время сушки, с
        public Parameter<short> DryUnitDryTime { get; } = new Parameter<short>(nameof(DryUnitDryTime), "Блок осушителя - время сушки, с", 0, 1000, 20016, 0);
        #endregion
        #region Время работы питателя в автоматическом режиме, с
        public Parameter<short> PitatelWorkTime { get; } = new Parameter<short>(nameof(PitatelWorkTime), "Время работы питателя в автоматическом режиме, с", 0, 1000, 20017, 0);
        #endregion
        #region Время работы системы возврата проб в автоматическом режиме, с
        public Parameter<short> SysReturnWorkTime { get; } = new Parameter<short>(nameof(SysReturnWorkTime), "Время работы системы возврата проб в автоматическом режиме, с", 0, 1000, 20018, 0);
        #endregion
        #region Время работы делителя в автоматическом режиме, с
        public Parameter<short> DelitelWorkTime { get; } = new Parameter<short>(nameof(DelitelWorkTime), "Время работы делителя в автоматическом режиме, с", 0, 1000, 20019, 0);
        #endregion
        #region Время работы истирателя в автоматическом режиме, с
        public Parameter<short> IstiratelWorkTime { get; } = new Parameter<short>(nameof(IstiratelWorkTime), "Время работы истирателя в автоматическом режиме, с", 0, 1000, 20020, 0);
        #endregion
        #region Блок осушителя, уставка температуры, С
        public Parameter<short> DryUnitTemperatureSv { get; } = new Parameter<short>(nameof(DryUnitTemperatureSv), "Блок осушителя, уставка температуры, С", 20, 300, 20021, 0);
        #endregion
        #region Время синхронизации, год
        public Parameter<short> DateSynchroYear { get; } = new Parameter<short>(nameof(DateSynchroYear), "Время синхронизации, год", 0, 99, 20022, 0);
        #endregion
        #region Время синхронизации, месяц
        public Parameter<short> DateSynchroMonth { get; } = new Parameter<short>(nameof(DateSynchroMonth), "Время синхронизации, месяц", 1, 12, 20023, 0);
        #endregion
        #region Время синхронизации, день
        public Parameter<short> DateSynchroDay { get; } = new Parameter<short>(nameof(DateSynchroDay), "Время синхронизации, день", 1, 31, 20024, 0);
        #endregion
        #region Время синхронизации, час
        public Parameter<short> DateSynchroHour { get; } = new Parameter<short>(nameof(DateSynchroHour), "Время синхронизации, час", 0, 23, 20025, 0);
        #endregion
        #region Время синхронизации, мин
        public Parameter<short> DateSynchroMin { get; } = new Parameter<short>(nameof(DateSynchroMin), "Время синхронизации, мин", 0, 59, 20026, 0);
        #endregion
        #region Время синхронизации, сек
        public Parameter<short> DateSynchroSec { get; } = new Parameter<short>(nameof(DateSynchroSec), "Время синхронизации, сек", 0, 59, 20027, 0);
        #endregion
        #region Время синхронизации, день недели
        public Parameter<short> DateSynchroDayOfWeek { get; } = new Parameter<short>(nameof(DateSynchroDayOfWeek), "Время синхронизации, день недели", 1, 7, 20028, 0);
        #endregion
        #region Тайм-аут движения ковша проботборника 1
        public Parameter<short> ProbotbornikTimeout1 { get; } = new Parameter<short>(nameof(ProbotbornikTimeout1), "Тайм-аут движения ковша проботборника 1, c", 1, 100, 20050, 0);
        #endregion
        #region Тайм-аут движения ковша проботборника 2
        public Parameter<short> ProbotbornikTimeout2 { get; } = new Parameter<short>(nameof(ProbotbornikTimeout2), "Тайм-аут движения ковша проботборника 2, c", 1, 100, 20051, 0);
        #endregion
    }
}
