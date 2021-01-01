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
        /// Свойство получения значения поля Index
        /// </summary>
        public int Index { get { return this.Index; } }

        public DataBase(string path)
        {
            this.dateBase= new List<DataFields>(3);
        }



        public void AddItemDB(DateTime data, string period, int cold, int hotter)
        {
            int count = dateBase.Count;
            int totalCold, totalHotter;
            if (count == 0)
            {
                totalCold = cold;
                totalHotter = hotter;
            }
            else
            {
                totalCold = cold - dateBase[count-1].Cold;
                totalHotter = hotter - dateBase[count-1].Hotter;
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
            for (int i = 0; i < dateBase.Count; i++)
            {
                Console.Write(
                    $"{dateBase[i].Date.ToString("d"),18} | {dateBase[i].Period,18} | {dateBase[i].Cold,18} | " +
                    $"{dateBase[i].Hotter,18} | {dateBase[i].TotalCold,18} | {dateBase[i].TotalHotter,18} |\n");

            }
        }
    }
}
