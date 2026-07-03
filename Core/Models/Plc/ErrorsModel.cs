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
                new Parameter<bool>("ErrNakopOpenDoor_3",           "Накопитель 3: открыта дверь",                          false, true, 30, 11),
                new Parameter<bool>("ErrNakopNoKanistra_3",         "Накопитель 3: нет канистры",                           false, true, 30, 12),
                new Parameter<bool>("ErrNakopFull_3",               "Накопитель 3 канистра заполнена",                      false, true, 30, 13),
                new Parameter<bool>("ErrNakopOpenDoor_10",          "Накопитель 10: открыта дверь",                         false, true, 30, 14),
                new Parameter<bool>("ErrNakopNoKanistra_10",        "Накопитель 10: нет канистры",                          false, true, 30, 15),
                new Parameter<bool>("ErrNakopFull_10",              "Накопитель 10: канистра заполнена",                    false, true, 31, 0),

                new Parameter<bool>("ErrProbSqLeft_1",              "Пробоотборник: сработал авар.датчик \"ЛЕВО\"",         false, true, 30, 0),
                new Parameter<bool>("ErrProbSqRight_1",             "Пробоотборник: сработал авар.датчик \"ПРАВО\"",        false, true, 30, 1),
                new Parameter<bool>("ErrProbDrive_1",               "Пробоотборник: нет готовности привода пробоотборника", false, true, 30, 2),
                new Parameter<bool>("ErrStopProb_1",                "Пробоотборник: нажата кнопка \"СТОП\"",                false, true, 30, 3),
                new Parameter<bool>("ErrProbNeedReturn_1",          "Пробоотборник: необходим возврат",                     false, true, 30, 4),
                new Parameter<bool>("ErrProbSqLeftTimeout_1",       "Пробоотборник: таймаут движения в \"ЛЕВО\"",           false, true, 30, 5),
                new Parameter<bool>("ErrProbSqRightTimeout_1",      "Пробоотборник: таймаут движения в \"ПРАВО\"",          false, true, 30, 6),

                new Parameter<bool>("ErrHardRemoteStopAsu",         "Аппаратный дистанционный стоп от АСУ",                 false, true, 30, 7),
                new Parameter<bool>("ErrSoftRemoteStopAsu",         "Программный дистанционный стоп от АСУ",                false, true, 30, 8),

                new Parameter<bool>("ErrNoFlow",                    "Нет потока",                                           false, true, 30, 9),

                new Parameter<bool>("ErrProbСommFc_1",              "Нет связи Modbus с ПЧ пробоотборника",                 false, true, 30, 10),

            };
        }

        

    }
}
