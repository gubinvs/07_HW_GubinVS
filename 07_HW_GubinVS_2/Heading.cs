using System;
using System.Collections.Generic;
using System.Text;

namespace _07_HW_GubinVS_2
{
    class Heading
    {
        #region Инициализация полей класса

        /// <summary>
        /// Поле с заголовком даты
        /// </summary>
        private string hdata = "Дата показаний";

        /// <summary>
        /// Поле с заголовком периода
        /// </summary>
        private string hperiod = "Период";


        /// <summary>
        /// Поле с заголовком показаний потребления холодного водоснабжения
        /// </summary>
        private string hcold = "Показания (ХВС)";


        /// <summary>
        /// Поле с заголовком показаний потребления горячего водоснабжения
        /// </summary>
        private string hhotter = "Показания (ГВС)";


        /// <summary>
        /// Поле с заголовком потребления за период (ХВС)
        /// </summary>
        private string htotalCold = "Потребление (ХВС)";


        /// <summary>
        /// Поле с заголовком потребления за период (ГВС)
        /// </summary>
        private string htotalHotter = "Потребление (ГВС)";


        #endregion Инициализация полей класса

        #region Методы

        /// <summary>
        /// Метод вывода заголовка таблицы в консоль
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"||{hdata,18} ||{hperiod,18} ||{hcold,18} ||{hhotter,18} ||{htotalCold,18} ||{htotalHotter,18} ||");
            //Console.WriteLine();
        }

        /// <summary>
        /// Метод вывода заголовка таблицы в консоль при добавлении записи с консоли
        /// </summary>
        public void PrintAdd()
        {
            Console.WriteLine($"||{hdata,18} ||{hperiod,18} ||{hcold,18} ||{hhotter,18} ||");
            //Console.WriteLine();
        }

        #endregion Методы

    }
}
