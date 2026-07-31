namespace Core.Models.Plc
{
    public class ErrorsModel
    {
        public ErrorsModel()
        {
            Init();
        }
        public List<Parameter<bool>> Errors { get; set; }

        public List<Parameter<bool>> Warnings { get; set; }
        private void Init()
        {
            Errors = new List<Parameter<bool>>
            {
                new Parameter<bool>("ErrNakopOpenDoor_3",           "Накопитель 3: открыта дверь",                          false, true, 30, 11) { RegType = Registers.Input, Advice = "Закройте дверь НП3"},
                new Parameter<bool>("ErrNakopNoKanistra_3",         "Накопитель 3: нет канистры",                           false, true, 30, 12) { RegType = Registers.Input, Advice = "Поместите канистру в НП3"},
                new Parameter<bool>("ErrNakopFull_3",               "Накопитель 3 канистра заполнена",                      false, true, 30, 13) { RegType = Registers.Input, Advice = "Обновите канистру в НП3"},
                new Parameter<bool>("ErrNakopOpenDoor_10",          "Накопитель 10: открыта дверь",                         false, true, 30, 14) { RegType = Registers.Input, Advice = "Закройте дверь НП10"},
                new Parameter<bool>("ErrNakopNoKanistra_10",        "Накопитель 10: нет канистры",                          false, true, 30, 15) { RegType = Registers.Input, Advice = "Поместите канистру в НП10"},
                new Parameter<bool>("ErrNakopFull_10",              "Накопитель 10: канистра заполнена",                    false, true, 31, 0)  { RegType = Registers.Input, Advice = "Обновите канистру НП10"},

                new Parameter<bool>("ErrProbSqLeft_1",              "Пробоотборник: сработал авар.датчик \"ЛЕВО\"",         false, true, 30, 0) { RegType = Registers.Input, Advice = "Вернуть ковш на штатную позицию"},
                new Parameter<bool>("ErrProbSqRight_1",             "Пробоотборник: сработал авар.датчик \"ПРАВО\"",        false, true, 30, 1) { RegType = Registers.Input, Advice = "Вернуть ковш на штатную позицию"},
                new Parameter<bool>("ErrProbDrive_1",               "Пробоотборник: нет готовности привода пробоотборника", false, true, 30, 2) { RegType = Registers.Input, Advice = "Проверить статус аварийного состояния ПЧ" },
                new Parameter<bool>("ErrStopProb_1",                "Пробоотборник: нажата кнопка \"СТОП\"",                false, true, 30, 3) { RegType = Registers.Input, Advice = "Отжать кнопку Аварийного останова" }    ,
                new Parameter<bool>("ErrProbNeedReturn_1",          "Пробоотборник: необходим возврат",                     false, true, 30, 4) { RegType = Registers.Input, Advice = "Ковш не в штатной позиции, вернуть с помощью кнопки \"возврата ковша\" или вручную, при наличии препятствия к движению" },
                new Parameter<bool>("ErrProbSqLeftTimeout_1",       "Пробоотборник: таймаут движения в \"ЛЕВО\"",           false, true, 30, 5) { RegType = Registers.Input, Advice = "Проверить состояние каретки ковша, вернуть ковш в штатное положение" },
                new Parameter<bool>("ErrProbSqRightTimeout_1",      "Пробоотборник: таймаут движения в \"ПРАВО\"",          false, true, 30, 6) { RegType = Registers.Input, Advice = "Проверить состояние каретки ковша, вернуть ковш в штатное положение" },

                new Parameter<bool>("ErrHardRemoteStopAsu",         "Аппаратный дистанционный стоп от АСУ",                 false, true, 30, 7) {RegType = Registers.Input, Advice = "Снять блокировку с АСУ" },
                new Parameter<bool>("ErrSoftRemoteStopAsu",         "Программный дистанционный стоп от АСУ",                false, true, 30, 8) {RegType = Registers.Input, Advice = "" },

                new Parameter<bool>("ErrNoFlow",                    "Нет потока",                                           false, true, 30, 9) { RegType = Registers.Input, Advice = "Проверить целостность датчика или подачу воды" },

                new Parameter<bool>("ErrProbСommFc_1",              "Нет связи Modbus с ПЧ пробоотборника",                 false, true, 30, 10) { RegType = Registers.Input, Advice = "Проверьте соединение кабелей." },

            };

            Warnings = new List<Parameter<bool>>
            {
                new Parameter<bool>("WarnRemoteMode",              "Дистанционный режим управления",                        false, true, 35, 0) { RegType = Registers.Input,  Advice =  ""},
                new Parameter<bool>("WarnLocalModeProb_1",         "Местный режим пробоотборника 1",                        false, true, 35, 1) { RegType = Registers.Input,  Advice = "Проверьте состояние ИБП" },
                new Parameter<bool>("WarnUpsFall",                 "ИБП: пропадание сети",                                  false, true, 35, 2) { RegType = Registers.Input,  Advice = "Проверьте состояние ИБП" },
                new Parameter<bool>("WarnUpsAlarm",                "ИБП: авария",                                           false, true, 35, 3) { RegType = Registers.Input,  Advice = "Проверьте состояние ИБП" },
                new Parameter<bool>("WarnUpsBypass",               "ИБП: режим байпас",                                     false, true, 35, 4) { RegType = Registers.Input,  Advice = "Проверьте состояние ИБП" },
                new Parameter<bool>("WarnUpsBatteryLow",           "ИБП: низкий заряд АКБ",                                 false, true, 35, 5) { RegType = Registers.Input,  Advice = "Проверьте состояние ИБП" },
                new Parameter<bool>("WarnUpsLineLoss",             "ИБП: потеря входной линии",                             false, true, 35, 6) { RegType = Registers.Input,  Advice = "Проверьте состояние ИБП" },
            };

        }

        

    }
}
