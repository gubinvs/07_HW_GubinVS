using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace _07_HW_GubinVS_2
{
    /// <summary>
    /// Структура содержит поля базы данных
    /// </summary>
    
    struct DataFields
    {
        #region Инициализация полей структуры

        /// <summary>
        /// Дата ввода информации
        /// </summary>
        private DateTime date;

        /// <summary>
        /// Период за который подается информация
        /// </summary>
        private string period;

        /// <summary>
        /// Показания счетчика холодного водостнабжения
        /// </summary>
        private int cold;

        /// <summary>
        /// Показания счетчика горячего водоснабжения
        /// </summary>
        private int hotter;


        /// <summary>
        /// Поле c данными о количестве потребления в отчетный период
        /// </summary>
        private int totalCold;


        /// <summary>
        /// Поле c данными о количестве потребления в отчетный период
        /// </summary>
        private int totalHotter;


        #endregion Инициализация полей структуры

        #region Свойства
        /// <summary>
        /// Свойство поля дата
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Свойство пля период
        /// </summary>
        public string Period { get; set; }

        /// <summary>
        /// Свойство поля (ХВС)
        /// </summary>
        public int Cold { get; set; }

        /// <summary>
        /// Свойство поля (ГВС)
        /// </summary>
        public int Hotter { get; set; }

        /// <summary>
        /// Свойство поля потребление (ХВС)
        /// </summary>
        public int TotalCold { get; set; }

        /// <summary>
        /// Свойство пля потребление (ГВС)
        /// </summary>
        public int TotalHotter { get; set; }

        #endregion Свойства




    }
}
