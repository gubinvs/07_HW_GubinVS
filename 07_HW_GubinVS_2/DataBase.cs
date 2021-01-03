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
        /// Список структур DataFields
        /// </summary>
        private List<DataFields> dateBase;


        /// <summary>
        /// Инициализация списка структур при создании экземпляра
        /// </summary>
        /// <param name="path">Путь к файлу с данными</param>
        public DataBase(string path)
        {
            this.dateBase= new List<DataFields>(3);
        }


        /// <summary>
        /// Метод заполнения структуры DataFields и добавление ее в список из принимаемого массива string[]
        /// </summary>
        /// <param name="array"></param>
        public void AddItemDBForArray(string[] array)
        {
            int count = dateBase.Count;
            int totalCold, totalHotter;
            if (count == 0)
            {
                totalCold = Convert.ToInt32(array[2]);
                totalHotter = Convert.ToInt32(array[3]);
            }
            else
            {
                totalCold = Convert.ToInt32(array[2]) - dateBase[count - 1].Cold;
                totalHotter = Convert.ToInt32(array[2]) - dateBase[count - 1].Hotter;
            }

            this.dateBase.Add(
                new DataFields()
                {
                    Date = Convert.ToDateTime(array[0]),
                    Period = array[1],
                    Cold = Convert.ToInt32(array[2]),
                    Hotter = Convert.ToInt32(array[3]),
                    TotalCold = totalCold,
                    TotalHotter = totalHotter,
                });



        }







        /// <summary>
        /// Метод добавления данных в список
        /// </summary>
        /// <param name="data">Дата записи</param>
        /// <param name="period">Период за который подаются данные</param>
        /// <param name="cold">Показания (ХВС)</param>
        /// <param name="hotter">Показания (ГВС)</param>
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



        /// <summary>
        /// Метод вывода данных списка структур в консоль
        /// </summary>
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
