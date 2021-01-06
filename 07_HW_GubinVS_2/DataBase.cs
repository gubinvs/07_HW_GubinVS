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






        /// <summary>
        /// Метод принимающий диапазон дат и удаляет все элементы списка не входящий в данный диапазон
        /// </summary>
        /// <param name="item"></param>
        /// <param name="item2"></param>
        public void Export(string item, string item2)
        {
            // Количество элементов в списке
            int count = this.dateBase.Count;
            

            // создание переменных в формате даты
            DateTime one = Convert.ToDateTime(item);
            DateTime two = Convert.ToDateTime(item2);

            // Определение индекса верхней и нижней границы диапазона
            int oneitem = this.dateBase.FindIndex(x => x.Date.ToString().Contains(item));
            int twoitem = this.dateBase.FindIndex(x => x.Date.ToString().Contains(item2));

            // сколько элементов переносится
            int index = (twoitem-oneitem)+1;            

            // Инициализация массива для заполнения его данными, которые деобходимо экспортировать
            DataFields[] array = new DataFields[index];

            // Заполнение массива данными структуры теми которые входят в диапазон значений
            for (int i = 0; i < index; i++)
            {
                if (this.dateBase[i].Date >= one & this.dateBase[i].Date <= two)
                {
                    Console.Write(array[i].Date = this.dateBase[i].Date);
                    Console.Write(array[i].Period = this.dateBase[i].Period);
                    Console.Write(array[i].Cold = this.dateBase[i].Cold);
                    Console.Write(array[i].Hotter = this.dateBase[i].Hotter);
                    Console.WriteLine();
                    
                }
    
            }

            //this.dateBase.Clear();
            

            for (int i = 0; i < index; i++)
            {
                Console.Write($"{array[i].Period}\n");
            }




            //// Заполнение списка из массива DataFields[]
            for (int i = 0; i < index; i++)
            {

                this.dateBase.Add(
                        new DataFields()
                            {
                                Date = array[i].Date,
                                Period = array[i].Period,
                                Cold = array[i].Cold,
                                Hotter = array[i].Hotter,
                                TotalCold = 0,
                                TotalHotter = 0

                            }
                );
            }


        }

        /// <summary>
        /// Метод удаления элемента списка по принимаемому индексу
        /// </summary>
        /// <param name="index">Индекс элемента для удаления</param>
        public void RemoveItem(int index)
        {
            if (index < 0)
            {
                Console.WriteLine("Выбранного периода нет в базе данных");
            }
            else
            {
                this.dateBase.RemoveAt(index);
            }
         
        }


        /// <summary>
        /// Метод вставляет элементы списка по указанному индексу
        /// принимает индекс и массив данных
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <param name="array">Массив данных</param>
        public void AddItemDBIndex(int index, string[] array)
        {
            int totalCold, totalHotter;
            if (index == 0)
            {
                totalCold = Convert.ToInt32(array[2]);
                totalHotter = Convert.ToInt32(array[3]);
            }
            else
            {
                totalCold = Convert.ToInt32(array[2]) - dateBase[index - 1].Cold;
                totalHotter = Convert.ToInt32(array[3]) - dateBase[index - 1].Hotter;
            }

            // Удаление выбранного элемента списка по индексу
            this.dateBase.RemoveAt(index);

            // Заполнение удаленного элемента новыми данными
            this.dateBase.Insert(index,
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
        /// Метод принимает значение, ищет первое вхождение в структуре и возвращает индекс
        /// элемента списка в котором имеется первое соответствие искомому элементу
        /// </summary>
        /// <param name="item">Искомый элемент</param>
        /// <returns></returns>
        public int IndexOf(string item)
        {
           return this.dateBase.FindIndex(x => x.Period.Contains(item));
        }


        /// <summary>
        /// Метод перерасчета данных о потреблении 
        /// </summary>
        public void RecalculateItem()
        {
            // Определяет количество элементов в базе данных
            int count = dateBase.Count;
            int totalCold, totalHotter;
            // Инициализация массива структуры
            DataFields[] array = new DataFields[count];
            // Копирование данных списка в массив структуры
            this.dateBase.CopyTo(array);
            // Очистка базы данных
            this.dateBase.Clear();

            // Заполнение списка из массива DataFields[]
            for (int i = 0; i < count; i++)
            {
                if (i==0)
                {
                    totalCold = array[i].Cold;
                    totalHotter = array[i].Hotter;

                }
                else
                {
                    totalCold = array[i].Cold - array[i-1].Cold;
                    totalHotter = array[i].Hotter - array[i-1].Hotter;
                }

                this.dateBase.Add(

                    new DataFields()
                    {
                        Date = array[i].Date,
                        Period = array[i].Period,
                        Cold = array[i].Cold,
                        Hotter = array[i].Hotter,
                        TotalCold = totalCold,
                        TotalHotter = totalHotter

                    }
                    );
            }
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
