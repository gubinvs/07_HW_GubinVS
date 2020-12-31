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
            int count = dateBase.Count;
            int totalCold, totalHotter;
            if (count == 0)
            {
                totalCold = cold;
                totalHotter = hotter;
                Console.WriteLine(count);
            }
            else
            {
                totalCold = 0;
                totalHotter = 0;
            }
            
            this.dateBase.Add(
                new DataFields()
                {
                    Date = Convert.ToDateTime(data),
                    Period = period,
                    Cold = cold,
                    Hotter = hotter,
                    TotalCold = totalCold,
                    TotalHotter = totalHotter,
                });
            
            
        }

        public void Print()
        {
            
            //foreach (var item in this.dateBase)
            //{
            //    Console.Write($"{item.Date.ToString("d"),15} | {item.Period,15} | {item.Cold,15} | {item.Hotter,15} | " +
            //        $"{item.TotalCold,15} | {item.TotalHotter,15} |"); 
            //}

            for (int i = 0; i < dateBase.Count; i++)
            {
                Console.Write($"{dateBase[i].Date.ToString("d"),15} | {dateBase[i].Period,15} | {dateBase[i].Cold,15} | " +
                    $"{dateBase[i].Hotter,15} | " +
                    $"{dateBase[i].TotalCold,15} | {dateBase[i].TotalHotter,15} |");
            }
        

        }


    }
}
