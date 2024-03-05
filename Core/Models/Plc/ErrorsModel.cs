namespace Core.Models.Plc
{
    public class ErrorsModel
    {
        public ErrorsModel()
        {
            Init();
        }
        public List<Parameter<bool>> Errors { get; set; }

        private void Init()
        {
            Errors = new List<Parameter<bool>>
            {
                new Parameter<bool>("ErrOpenDoor",                  "Накопитель: открыта дверь",                            false, true, 202, 0),
                new Parameter<bool>("ErrNakopTimeoutCalibration",   "Накопитель: таум-аут калибровки",                      false, true, 202, 1),
                new Parameter<bool>("ErrNakopTimeoutMoving",        "Накопитель: тайм-аут смены канистры",                  false, true, 202, 2),
                new Parameter<bool>("ErrNakopNoKanistres",          "Накопитель: нет канистр",                              false, true, 202, 3),
                new Parameter<bool>("ErrNakopFull",                 "Накопитель: все канистры заполнены",                   false, true, 202, 4),
                new Parameter<bool>("ErrNakopDrive",                "Накопитель: ошибка ПЧ",                                false, true, 202, 5),
                new Parameter<bool>("ErrSqRight1",                  "Пробоотборник 1: сработал авар.датчик \"ПРАВО\"",      false, true, 202, 6),
                new Parameter<bool>("ErrSqLeft1",                   "Пробоотборник 1: сработал авар.датчик \"ЛЕВО\"",       false, true, 202, 7),
                new Parameter<bool>("ErrSqRightTimeout1",           "Пробоотборник 1: таймаут движения в \"ПРАВО\"",        false, true, 202, 8),
                new Parameter<bool>("ErrSqLeftTimeout1",            "Пробоотборник 1: таймаут движения в \"ЛЕВО\"",         false, true, 202, 9),
                new Parameter<bool>("ErrNeedReturn1",               "Пробоотборник 1: необходим возврат",                   false, true, 202, 10),
                new Parameter<bool>("ErrDrive1",                    "Пробоотборник 1: ошибка ПЧ",                           false, true, 202, 11),
                new Parameter<bool>("ErrSqRight2",                  "Пробоотборник 2: ошибка датчика положения 1",          false, true, 202, 12),
                new Parameter<bool>("ErrSqLeft2",                   "Пробоотборник 2: ошибка датчика положения 2",          false, true, 202, 13),
                new Parameter<bool>("ErrSqRightTimeout2",           "Пробоотборник 2: таймаут движения в \"ПРАВО\"",        false, true, 202, 14),
                new Parameter<bool>("ErrSqLeftTimeout2",            "Пробоотборник 2: таймаут движения в \"ЛЕВО\"",         false, true, 202, 15),
                new Parameter<bool>("ErrNeedReturn2",               "Пробоотборник 2: необходим возврат",                   false, true, 203, 0),
                new Parameter<bool>("ErrDrive2",                    "Пробоотборник 2: ошибка ПЧ",                           false, true, 203, 1),
                new Parameter<bool>("ErrDryOpenHighShiberTimeout",  "Блок сушки: тайм-аут открытия шибера \"Верх\"",        false, true, 203, 2),
                new Parameter<bool>("ErrDryCloseHighShiberTimeout", "Блок сушки: тайм-аут закрытия шибера \"Верх\"",        false, true, 203, 3),
                new Parameter<bool>("ErrDryOpenLowShiberTimeout",   "Блок сушки: тайм-аут открытия шибера \"Низ\"",         false, true, 203, 4),
                new Parameter<bool>("ErrDryCloseLowShiberTimeout",  "Блок сушки: тайм-аут закрытия шибера \"Низ\"",         false, true, 203, 5),
                new Parameter<bool>("ErrDryUpBarabanTimeout",       "Блок сушки: тайм-аут поднятия барабана",               false, true, 203, 6),
                new Parameter<bool>("ErrDryDownBarabanTimeout",     "Блок сушки: тайм-аут опускания барабана",              false, true, 203, 7),
                new Parameter<bool>("ErrDryOpenLowShiberPosition",  "Блок сушки: шибер \"Низ\" вне положений",              false, true, 203, 8),
                new Parameter<bool>("ErrDryOpenhighShiberPosition", "Блок сушки: шибер \"Верх\" вне положений",             false, true, 203, 9),
                new Parameter<bool>("ErrDryBarabanPosition",        "Блок сушки: барабан вне положений",                    false, true, 203, 10),
                new Parameter<bool>("ErrСommFcProb1",               "Нет связи Modbus с ПЧ перв. пробоотборника",           false, true, 203, 11),
                new Parameter<bool>("ErrСommFcPitatel",             "Нет связи Modbus с ПЧ питателя",                       false, true, 203, 12),
                new Parameter<bool>("ErrСommFcProb2",               "Нет связи Modbus с ПЧ втор. Пробоотборника",           false, true, 203, 13),
                new Parameter<bool>("ErrСommNakop",                 "Нет связи Modbus с ПЧ накопителя",                     false, true, 203, 14),
                new Parameter<bool>("ErrСommTermoUnit",             "Нет связи Modbus с регулятором температуры" ,          false, true, 203, 15),
                new Parameter<bool>("ErrСommHummMeasureUnit",       "Нет связи с измерителем влажности по Modbus",          false, true, 204, 0),
                new Parameter<bool>("ErrStopProb1",                 "Пробоотборник 1: нажата кнопка \"СТОП\"",              false, true, 204, 1),
                new Parameter<bool>("ErrStopCabinetProb1",          "Шкаф управления: нажата кнопка \"СТОП перв.пробоотборник\"", false, true, 204, 2),
                new Parameter<bool>("ErrStopProb1",                 "Пробоотборник 2: нажата кнопка \"СТОП\"",              false, true, 204, 3),
                new Parameter<bool>("ErrStopCabinetProb1",          "Шкаф управления: нажата кнопка \"СТОП втор.пробоотборник\"", false, true, 204, 4),
                new Parameter<bool>("ErrStopNakop",                 "Накопитель: нажата кнопка \"СТОП\"",                   false, true, 204, 5),
                new Parameter<bool>("ErrStopNakopCabinet",          "Шкаф управления: нажата кнопка \"СТОП накопитель\"",   false, true, 204, 6),
                new Parameter<bool>("ErrPitetelFilmDevRight",       "Питатель: отклонение ленты \"Право\"",                 false, true, 204, 7),
                new Parameter<bool>("ErrPitetelFilmDevLeft",        "Питатель: отклонение ленты \"Лево\"",                  false, true, 204, 8),
                new Parameter<bool>("ErrPitetelStop",               "Питатель: нажата кнопка \"СТОП\"",                     false, true, 204, 9),
                new Parameter<bool>("ErrPitetelStopCabinet",        "Шкаф управления: нажата кнопка \"СТОП питатель\"",     false, true, 204, 10),
                new Parameter<bool>("ErrSysRetFilmDevRight",        "Система возврата: отклонение ленты \"Право\"",         false, true, 204, 11),
                new Parameter<bool>("ErrSysRetFilmDevLeft",         "Система возврата: отклонение ленты \"Лево\"",          false, true, 204, 12),
                new Parameter<bool>("ErrSysRetStop",                "Система возврата: нажата кнопка \"СТОП\"",             false, true, 204, 13),
                new Parameter<bool>("ErrSysRetStopCabinet",         "Шкаф управления: нажата кнопка \"СТОП система возврата\"", false, true, 204, 14),
                new Parameter<bool>("ErrPitetelDrive",              "Питатель: ошибка ПЧ",                                  false, true, 204, 15),
                new Parameter<bool>("ErrSysReturnDrive",            "Система возврата: сработало тепловое реле",            false, true, 205, 0),
                new Parameter<bool>("ErrStopDrobilkaCabinet",       "Шкаф управления: нажата кнопка \"СТОП дробилка\"",     false, true, 205, 1),
                new Parameter<bool>("ErrStopIstiratelCabinet",      "Шкаф управления: нажата кнопка \"СТОП истиратель\"",   false, true, 205, 2),
                new Parameter<bool>("ErrStopDryUnitCabinet",        "Шкаф управления: нажата кнопка \"СТОП блок сушки\"",   false, true, 205, 3),
                new Parameter<bool>("ErrStopDrobilka",              "Дробилка: нажата кнопка \"СТОП\"",                     false, true, 205, 4),
                new Parameter<bool>("ErrSqDrobilka",                "Дробилка: аварийный концевик",                         false, true, 205, 5),
                new Parameter<bool>("ErrDryUnitStop",               "Блок сушки: нажата кнопка \"СТОП\"",                   false, true, 205, 6),
                new Parameter<bool>("ErrStopIstiratel",             "Истиратель: нажата кнопка \"СТОП\"",                   false, true, 205, 7),
                new Parameter<bool>("ErrSqIstiratel1",              "Истиратель: аварийный концевик 1",                     false, true, 205, 8),
                new Parameter<bool>("ErrSqIstiratel2",              "Истиратель: аварийный концевик 2",                     false, true, 205, 9),
                new Parameter<bool>("ErrDrobilkaDrive",             "Дробилка: сработало тепловое реле",                    false, true, 205, 10),
                new Parameter<bool>("ErrIstiratelDrive",            "Истиратель: сработало тепловое реле",                  false, true, 205, 11),
                new Parameter<bool>("ErrDryUnitDrive",              "Блок сушки: сработало тепловое реле",                  false, true, 205, 12),
                new Parameter<bool>("ErrKonveyor39",                "Нет готовности от конвеера 39",                        false, true, 205, 13)

            };
        }

        

    }
}
