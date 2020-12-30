using System;
using System.Collections.Generic;
using System.Text;

namespace _07_HW_GubinVS_2
{
    /// <summary>
    /// Структура содержит поля базы данных
    /// </summary>
    struct DataFields
    {
        /// <summary>
        /// Поле дата
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Поле период
        /// </summary>
        public string Period { get; set; }

        /// <summary>
        /// Поле данных о (ХВС)
        /// </summary>
        public int Cold { get; set; }

        /// <summary>
        /// Поле данных о (ГВС)
        /// </summary>
        public int Hotter { get; set; }

        /// <summary>
        /// Поле данных о потреблении (ХВС)
        /// </summary>
        public int TotalCold { get; set; }

        /// <summary>
        /// Поле данных о потреблении (ГВС)
        /// </summary>
        public int TotalHotter { get; set; }


    }
}
