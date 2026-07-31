namespace Core.Models.Plc
{
    public class DiModel
    {
        #region Проботборник
        //#region Проботборник 1 - аварийный датчик начального положения
        //public Parameter<bool> SqProbHomeAbort1 { get; } = new Parameter<bool>(nameof(SqProbHomeAbort1), "Аварийный датчик начального положения", false, true, 32769, 0) { IsOnlyRead = true, RegType = Registers.Input };
        //#endregion
        //#region Проботборник 1 - датчик начального положения
        //public Parameter<bool> SqProbHome1 { get; } = new Parameter<bool>(nameof(SqProbHome1), "Датчик начального положения", false, true, 32769, 1) { IsOnlyRead = true, RegType = Registers.Input };
        //#endregion
        //#region Проботборник 1 - аварийный датчик рабочего положения
        //public Parameter<bool> SqProbWorkAbort1 { get; } = new Parameter<bool>(nameof(SqProbWorkAbort1), "Аварийный датчик рабочего положения", false, true, 32769, 2) { IsOnlyRead = true, RegType = Registers.Input };
        //#endregion
        //#region Проботборник 1 - датчик рабочего положения
        //public Parameter<bool> SqProbWork1 { get; } = new Parameter<bool>(nameof(SqProbWork1), "Датчик рабочего положения", false, true, 32769, 3) { IsOnlyRead = true, RegType = Registers.Input };
        //#endregion

        #region Аварийный концевик "ЛЕВО"

        public Parameter<bool> SqProbLeftAlarm { get; } = new Parameter<bool>(nameof(SqProbLeftAlarm), "Аварийный концевик \"ЛЕВО\"", false, true, 0, 2) { IsOnlyRead = true, RegType = Registers.Input };

        #endregion

        #region sq_left — рабочий концевик «ЛЕВО»

        public Parameter<bool> SqProbLeft { get; } = new Parameter<bool>(nameof(SqProbLeft), "Рабочий концевик «ЛЕВО»", false, true, 0, 3) { IsOnlyRead = true, RegType = Registers.Input };

        #endregion

        #region sq_right_alarm — аварийный концевик «ПРАВО»

        public Parameter<bool> SqProbRightAlarm { get; } = new Parameter<bool>(nameof(SqProbRightAlarm), "Аварийный концевик «ПРАВО»", false, true, 0, 4) { IsOnlyRead = true, RegType = Registers.Input };

        #endregion

        #region sq_right — рабочий концевик «ПРАВО»

        public Parameter<bool> SqProbRight { get; } = new Parameter<bool>(nameof(SqProbRight), "Рабочий концевик «ПРАВО»", false, true, 0, 5) { IsOnlyRead = true, RegType = Registers.Input };

        #endregion

        #region sb_local_remote — переключатель местный/дист.
        public Parameter<bool> SqProbLocalRemote { get; } = new Parameter<bool>(nameof(SqProbLocalRemote), "Переключатель местный/дистанционный", false, true, 0, 6) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion

        #region sb_stop — кнопка «Стоп»
        public Parameter<bool> SqProbSbStop { get; } = new Parameter<bool>(nameof(SqProbSbStop), "Кнопка «Стоп»", false, true, 0, 7) { IsOnlyRead = true, RegType = Registers.Input };

        #endregion

        #region fc_ready — ПЧ готов
        public Parameter<bool> SqProbFcReady { get; } = new Parameter<bool>(nameof(SqProbFcReady), "ПЧ готов", false, true, 0, 8) { IsOnlyRead = true, RegType = Registers.Input };

        #endregion

        #region fc_forw — ПЧ вращение «Вперёд»
        public Parameter<bool> SqProbFcForw { get; } = new Parameter<bool>(nameof(SqProbFcForw), "ПЧ вращение «Вперёд»", false, true, 0, 9) { IsOnlyRead = true, RegType = Registers.Input };

        #endregion 

        #region fc_rev — ПЧ вращение «Назад»
        public Parameter<bool> SqProbFcRev { get; } = new Parameter<bool>(nameof(SqProbFcRev), "ПЧ вращение «Назад»", false, true, 0, 10) { IsOnlyRead = true, RegType = Registers.Input };

        #endregion

        #region q_valve — клапан (промывка)
        public Parameter<bool> SqProbQValve { get; } = new Parameter<bool>(nameof(SqProbQValve), "Клапан (промывка)", false, true, 0, 11) { IsOnlyRead = true, RegType = Registers.Input };

        #endregion

        #region fc_comm — связь с ПЧ
        public Parameter<bool> SqProbFcComm { get; } = new Parameter<bool>(nameof(SqProbFcComm), "Связь с ПЧ", false, true, 0, 12) { IsOnlyRead = true, RegType = Registers.Input };

        #endregion

        #region Код ошибки ПЧ

        public Parameter<string> SqProbFcErrorCode { get; } = new Parameter<string>(nameof(SqProbFcComm), "Код ошибки ПЧ", string.Empty, "ZZZZZZZZZZZZZZZZZZZZZZZ", 1, 0) { Length = 12, IsOnlyRead = true, RegType = Registers.Input };

        #endregion



        #endregion

        //#region Проботборник 2 - аварийный датчик начального положения
        //public Parameter<bool> SqProbHomeAbort2 { get; } = new Parameter<bool>(nameof(SqProbHomeAbort2), "Аварийный датчик начального положения", false, true, 32769, 8) { IsOnlyRead = true, RegType = Registers.Input };
        //#endregion
        //#region Проботборник 2 - датчик начального положения
        //public Parameter<bool> SqProbHome2 { get; } = new Parameter<bool>(nameof(SqProbHome2), "Датчик начального положения", false, true, 32769, 9) { IsOnlyRead = true, RegType = Registers.Input };
        //#endregion
        //#region Проботборник 2 - аварийный датчик рабочего положения
        //public Parameter<bool> SqProbWorkAbort2 { get; } = new Parameter<bool>(nameof(SqProbWorkAbort2), "Аварийный датчик рабочего положения", false, true, 32769, 10) { IsOnlyRead = true, RegType = Registers.Input };
        //#endregion
        //#region Проботборник 2 - датчик рабочего положения
        //public Parameter<bool> SqProbWork2 { get; } = new Parameter<bool>(nameof(SqProbWork2), "Датчик рабочего положения", false, true, 32769, 11) { IsOnlyRead = true, RegType = Registers.Input };
        //#endregion


        //#region Сушка  - верхний шибер открыт
        //public Parameter<bool> SqDryHighShiberOpened { get; } = new Parameter<bool>(nameof(SqDryHighShiberOpened), "Верхний шибер открыт", false, true, 32768, 8) { IsOnlyRead = true, RegType = Registers.Input };
        //#endregion
        //#region Сушка  - верхний шибер закрыт
        //public Parameter<bool> SqDryHighShiberClosed { get; } = new Parameter<bool>(nameof(SqDryHighShiberClosed), "Верхний шибер закрыт", false, true, 32768, 9) { IsOnlyRead = true, RegType = Registers.Input };
        //#endregion
        //#region Сушка  - нижний шибер открыт
        //public Parameter<bool> SqDryLowShiberOpened { get; } = new Parameter<bool>(nameof(SqDryLowShiberOpened), "Нижний шибер открыт", false, true, 32768, 10) { IsOnlyRead = true, RegType = Registers.Input };
        //#endregion
        //#region Сушка  - нижний шибер закрыт
        //public Parameter<bool> SqDryLowShiberClosed { get; } = new Parameter<bool>(nameof(SqDryLowShiberClosed), "Нижний шибер закрыт", false, true, 32768, 11) { IsOnlyRead = true, RegType = Registers.Input };
        //#endregion
        //#region Сушка  - барабан внизу
        //public Parameter<bool> SqBarabanLowPosition { get; } = new Parameter<bool>(nameof(SqBarabanLowPosition), "Барабан внизу", false, true, 32768, 12) { IsOnlyRead = true, RegType = Registers.Input };
        //#endregion
        //#region Сушка  - барабан вверху
        //public Parameter<bool> SqBarabanHighPosition { get; } = new Parameter<bool>(nameof(SqBarabanHighPosition), "Барабан вверху", false, true, 32768, 13) { IsOnlyRead = true, RegType = Registers.Input };
        //#endregion

        #region Состояние ИБП

        #region fall — пропадание сети

        public Parameter<bool> UpsFall { get; } = new Parameter<bool>(nameof(UpsFall), "Пропадание сети", false, true, 9, 0) { IsOnlyRead = true, RegType = Registers.Input };

        #endregion

        #region alarm — авария ИБП

        public Parameter<bool> UpsAlarm { get; } = new Parameter<bool>(nameof(UpsAlarm), "Авария ИБП", false, true, 9, 1) { IsOnlyRead = true, RegType = Registers.Input };

        #endregion

        #region bypass — режим байпас
        public Parameter<bool> UpsBypass { get; } = new Parameter<bool>(nameof(UpsBypass), "Режим ByPass", false, true, 9, 2) { IsOnlyRead = true, RegType = Registers.Input };

        #endregion

        #region battery_low — низкий заряд АКБ
        public Parameter<bool> UpsBatteryLow { get; } = new Parameter<bool>(nameof(UpsBatteryLow), "Низкий заряд АКБ", false, true, 9, 3) { IsOnlyRead = true, RegType = Registers.Input };

        #endregion

        #region ups_on — ИБП включён
        public Parameter<bool> UpsOn { get; } = new Parameter<bool>(nameof(UpsOn), "ИБП включён", false, true, 9, 4) { IsOnlyRead = true, RegType = Registers.Input };

        #endregion

        #region line_loss — потеря входной линии
        public Parameter<bool> UpsLineLoss { get; } = new Parameter<bool>(nameof(UpsLineLoss), "Потеря входной линии", false, true, 9, 5) { IsOnlyRead = true, RegType = Registers.Input };

        #endregion

        #endregion


        #region Накопитель 3 - датчик двери
        public Parameter<bool> SqDoorNakopitel { get; } = new Parameter<bool>(nameof(SqDoorNakopitel), "Датчик двери", false, true, 10, 0) { IsOnlyRead = true, RegType = Registers.Input, Value = true };
        #endregion
        #region Накопитель 3 - датчик полного оборота
        //public Parameter<bool> SqNakopFullRev { get; } = new Parameter<bool>(nameof(SqNakopFullRev), "Датчик полного оборота", false, true, 32770, 9) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion
        #region Накопитель 3 - датчик ячейки
        //public Parameter<bool> SqNakopCell { get; } = new Parameter<bool>(nameof(SqNakopCell), "Датчик ячейки", false, true, 32770, 8) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion
        #region Накопитель 3 - датчик канистры
        public Parameter<bool> SqNakopKanistra { get; } = new Parameter<bool>(nameof(SqNakopKanistra), "Датчик канистры", false, true, 10, 1) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion

        #region Накопитель 10 - датчик двери
        public Parameter<bool> SqDoorNakopitel10 { get; } = new Parameter<bool>(nameof(SqDoorNakopitel10), "Датчик двери НП10", false, true, 15, 0) { IsOnlyRead = true, RegType = Registers.Input, Value = true };
        #endregion

        #region Накопитель 10 - датчик канистры
        public Parameter<bool> SqNakopKanistra10 { get; } = new Parameter<bool>(nameof(SqNakopKanistra), "Датчик канистры", false, true, 15, 1) { IsOnlyRead = true, RegType = Registers.Input };
        #endregion

        //#region Шибер - сушка выключена
        //public Parameter<bool> SqDryValveOff { get; } = 
        //    new Parameter<bool>(nameof(SqDryValveOff), "Шибер - сушка выключена", false, true, 32771, 9){ IsOnlyRead = true, RegType = Registers.Input };

        //#endregion
        
        //#region Шибер - сушка выключена
        //public Parameter<bool> SqDryValveOn { get; } = 
        //    new Parameter<bool>(nameof(SqDryValveOn), "Шибер - сушка включена", false, true, 32771, 10){ IsOnlyRead = true, RegType = Registers.Input };

        //#endregion
        
        
    }
}

