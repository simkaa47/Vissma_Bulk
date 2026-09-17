using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.JsonData
{
    public class JsonData : ObservableObject
    {

        #region Имя
        /// <summary>
        /// Имя
        /// </summary>
        private string _name;
        /// <summary>
        /// Имя
        /// </summary>
        [MinLength(3)]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        #endregion

        #region Дата создания
        /// <summary>
        /// Дата создания
        /// </summary>
        private DateTime _changeTime;
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime ChangeTime
        {
            get => _changeTime;
            set => SetProperty(ref _changeTime, value);
        }
        #endregion



    }
}
