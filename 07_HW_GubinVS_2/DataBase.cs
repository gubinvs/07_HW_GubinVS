using System;
using System.Collections.Generic;
using System.Text;

namespace _07_HW_GubinVS_2
{

    /// <summary>
    /// Структура содержащая список структурированных данных
    /// о показаниях приборов учета водоснабжения
    /// </summary>
    struct DataBase
    {
        /// <summary>
        /// Список структур
        /// </summary>
        private List<DataFields> dateBase;

        /// <summary>
        /// Поле со значением количества записей в базе данных
        /// </summary>
        private int index;


        /// <summary>
        /// Свойство получения значения поля Index
        /// </summary>
        public int Index { get { return this.Index; } }

 



        public void AddItemDB(DateTime data, string period, int cold, int hotter)
        {

            this.dateBase = new List<DataFields>();
            this.dateBase.Add(
                new DataFields() 
                { 
                    Date = Convert.ToDateTime(data), 
                    Period = period, 
                    Cold = cold, 
                    Hotter = hotter,       
                    TotalCold = cold,
                    TotalHotter = hotter,
                });
            
        }

        public void Print()
        {
            
        
        
        }


    }
}
