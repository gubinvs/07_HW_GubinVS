using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace _07_HW_GubinVS_2
{
    /// <summary>
    /// Структура содержит поля базы данных
    /// </summary>
    
    struct DataFields : IComparable<DataFields>
    {
        
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

        public int CompareTo([AllowNull] DataFields other)
        {
            if (other.TotalCold < this.TotalCold)
            {
                return -1;
            }
            else if (other.TotalCold > this.TotalCold)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
