using System;
using System.Collections.Generic;
using System.IO;
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



        public void IndexOfff(DateTime item)
        {
            this.dateBase.IndexOf(new DataFields(),);
        
        }

        /// <summary>
        /// Метод считывает данные из файла и заполняет список структур данными считанными из файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void ReadFileSecond(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                if (sr.Read() > -1)  // Проверка есть данные в файле или нет
                {
                    while (!sr.EndOfStream)
                    {
                        string[] args = sr.ReadLine().Split(',');
                        AddItemDB(
                            Convert.ToDateTime(args[0]),
                            Convert.ToString(args[1]),
                            Convert.ToInt32(args[2]),
                            Convert.ToInt32(args[3])

                            );
                    }
                }
                else
                {
                    Console.WriteLine("Файл не содержит данных!");
                }

            }

        }

        /// <summary>
        /// Метод считывает данные из файла и заполняет список структур данными считанными из файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void ReadFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                if (sr.Read() > -1)  // Проверка есть данные в файле или нет
                {
                    while (!sr.EndOfStream)
                    {
                        string[] args = sr.ReadLine().Split(',');
                        AddItemDBFromFile(
                            Convert.ToDateTime(args[0]),
                            Convert.ToString(args[1]),
                            Convert.ToInt32(args[2]),
                            Convert.ToInt32(args[3]),
                            Convert.ToInt32(args[4]),
                            Convert.ToInt32(args[5])
                            );
                    }
                }
                else
                {
                    Console.WriteLine("Файл не содержит данных!");
                }

            }

        }

        /// <summary>
        /// Создает поток для записии данных массива в текстовой файл
        /// </summary>
        /// <param name="path">Путь к файлу для записи данных полей</param>
        public void WriteFile(string path)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {

                for (int i = 0; i < dateBase.Count; i++)
                {

                    sw.Write(dateBase[i].Date.ToString("d"));
                    sw.Write(",");
                    sw.Write(dateBase[i].Period);
                    sw.Write(",");
                    sw.Write(dateBase[i].Cold);
                    sw.Write(",");
                    sw.Write(dateBase[i].Hotter);
                    sw.Write(",");
                    sw.Write(dateBase[i].TotalCold);
                    sw.Write(",");
                    sw.Write(dateBase[i].TotalHotter);
                    sw.Write("\n");

                }
            }
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
                totalHotter = Convert.ToInt32(array[3]) - dateBase[count - 1].Hotter;
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
        /// Метод добавления данных в список
        /// </summary>
        /// <param name="data">Дата записи</param>
        /// <param name="period">Период за который подаются данные</param>
        /// <param name="cold">Показания (ХВС)</param>
        /// <param name="hotter">Показания (ГВС)</param>
        public void AddItemDBFromFile(DateTime data, string period, int cold, int hotter, int totalCold, int totalHotter)
        {
           
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
