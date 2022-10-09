using MyApp;
using System;
using System.Text;
namespace MyApp // Note: actual namespace depends on the project name.
{
    struct Horoscope
    {
        public string day;
        public string month;
        public string year;
        public string horoSlavs;
        public string horoJapan;
        public void show()
        {
            Console.WriteLine("{0,-15} {1,-15} {2,-15} {3, -15} {4, -15}", day, month, year, horoSlavs, horoJapan);
        }
        public string concat()
        {
            return $"{day};{month};{year};{horoSlavs};{horoJapan}";
        }

    }
    public class Program
    {
        static void getData(string path, List<Horoscope> L)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(";");
                    L.Add(new Horoscope()
                    {
                        day = array[0],
                        month = array[1],
                        year = array[2]
                    });
                }
            }
        }

        static void printData(List<Horoscope> L)
        {
            foreach (Horoscope h in L)
            {
                h.show();
            }
        }

        static void createFile(string path, List<Horoscope> L)
        {
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                foreach (Horoscope h in L)
                {
                    sw.WriteLine(h.concat());
                }
            }
        }

        static void check(List<Horoscope> L)
        {
            for (int i = 1; i < L.Count; i++)
            {
                Horoscope h = L[i];
                int forParse = 0;

                if (h.day == "" || h.month == "" || !int.TryParse(h.day, out forParse) || !int.TryParse(h.month, out forParse))
                {
                    h.horoSlavs = "Невозможно определить покровителя по Славянскому гороскопу!";
                }

                else if (Convert.ToInt32(h.day) <= 0 || Convert.ToInt32(h.day) > 31 || (Convert.ToInt32(h.day) > 28 && Convert.ToInt32(h.month) == 2) || Convert.ToInt32(h.month) <= 0 || Convert.ToInt32(h.month) > 12)
                {
                    h.horoSlavs = "Невозможно определить покровителя по Славянскому гороскопу!";
                }

                else
                {
                    if ((Convert.ToInt32(h.month) == 12 && Convert.ToInt32(h.day) >= 24 && Convert.ToInt32(h.day) <= 31) || (Convert.ToInt32(h.month) == 1 && Convert.ToInt32(h.day) <= 30))
                    {
                        h.horoSlavs = "Ваш покровитель - Мороз (Морозко, Трескун, Студенец). Бог-покровитель зимнего холода";
                    }
                    else if ((Convert.ToInt32(h.month) == 1 && Convert.ToInt32(h.day) == 31) || (Convert.ToInt32(h.month) == 2 && Convert.ToInt32(h.day) <= 28))
                    {
                        h.horoSlavs = "Ваш покровитель - Велес. Бог-медведь, покровитель охотников";
                    }
                    else if ((Convert.ToInt32(h.month) == 3 && Convert.ToInt32(h.day) <= 31))
                    {
                        h.horoSlavs = "Ваш покровитель - Макошь. Жена Велеса, богиня судьбы, плодородия и семейного очага";
                    }
                    else if ((Convert.ToInt32(h.month) == 4 && Convert.ToInt32(h.day) <= 30))
                    {
                        h.horoSlavs = "Ваш покровитель - Жива. Богиня плодородия, юности и красоты";
                    }
                    else if ((Convert.ToInt32(h.month) == 5 && Convert.ToInt32(h.day) <= 14))
                    {
                        h.horoSlavs = "Ваш покровитель - Ярила (Ярило). Бог весны и расцвета всех жизненных сил человека";
                    }
                    else if ((Convert.ToInt32(h.month) == 5 && Convert.ToInt32(h.day) >= 15 && Convert.ToInt32(h.day) <= 31) || (Convert.ToInt32(h.month) == 6 && Convert.ToInt32(h.day) <= 2))
                    {
                        h.horoSlavs = "Ваш покровитель - Леля. Богиня девичьей любви, красоты и счастья";
                    }
                    else if ((Convert.ToInt32(h.month) == 6 && Convert.ToInt32(h.day) >= 2  && Convert.ToInt32(h.day) <= 12))
                    {
                        h.horoSlavs = "Ваш покровитель - Кострома. Покровительница плодородия и лета.";
                    }
                    else if ((Convert.ToInt32(h.month) == 6 && Convert.ToInt32(h.day) >= 13 && Convert.ToInt32(h.day) <= 30) || (Convert.ToInt32(h.month) == 7 && Convert.ToInt32(h.day) <= 6))
                    {
                        h.horoSlavs = "Ваш покровитель - Додола. Богиня молодости, лета, песен и веселья. Также упоминается в обрядах-вызова дождя";
                    }
                    else if ((Convert.ToInt32(h.month) == 7 && Convert.ToInt32(h.day) == 24))
                    {
                        h.horoSlavs = "Ваш покровитель - Иван Купала. Праздник Солнца, зрелости лета и зеленого покоса";
                    }
                    else if ((Convert.ToInt32(h.month) == 7 && Convert.ToInt32(h.day) >= 7 && Convert.ToInt32(h.day) <= 31))
                    {
                        h.horoSlavs = "Ваш покровитель - Лада. Богиня-мать, храничельница домашнего очага";
                    }
                    else if ((Convert.ToInt32(h.month) == 8 && Convert.ToInt32(h.day) >= 1 && Convert.ToInt32(h.day) <= 28))
                    {
                        h.horoSlavs = "Ваш покровитель - Перун. Бог-громовержец";

                    }
                    else if ((Convert.ToInt32(h.month) == 8 && Convert.ToInt32(h.day) >= 29 && Convert.ToInt32(h.day) <= 31) || (Convert.ToInt32(h.month) == 9 && Convert.ToInt32(h.day) <= 13))
                    {
                        h.horoSlavs = "Ваш покровитель - Сева. Богиня садовых плодов";
                    }
                    else if ((Convert.ToInt32(h.month) == 9 && Convert.ToInt32(h.day) >= 14 && Convert.ToInt32(h.day) <= 27))
                    {
                        h.horoSlavs = "Ваш покровитель - Рожаница. Повелительница жизни и плодородия";
                    }
                    else if ((Convert.ToInt32(h.month) == 9 && Convert.ToInt32(h.day) >= 28 && Convert.ToInt32(h.day) <= 30) || (Convert.ToInt32(h.month) == 10 && Convert.ToInt32(h.day) <= 15))
                    {
                        h.horoSlavs = "Ваш покровитель - Сварожник. Дети Сварога, Бога огня";
                    }
                    else if ((Convert.ToInt32(h.month) == 10 && Convert.ToInt32(h.day) >= 16 && Convert.ToInt32(h.day) <= 31) || (Convert.ToInt32(h.month) == 11 && Convert.ToInt32(h.day) <= 8))
                    {
                        h.horoSlavs = "Ваш покровитель - Морена. Богиня увядания и смерти";

                    }
                    else if ((Convert.ToInt32(h.month) == 11 && Convert.ToInt32(h.day) >= 9 && Convert.ToInt32(h.day) <= 28))
                    {
                        h.horoSlavs = "Ваш покровитель - Зима.";
                    }
                    else if ((Convert.ToInt32(h.month) == 11 && Convert.ToInt32(h.day) >= 29 && Convert.ToInt32(h.day) <= 30) || (Convert.ToInt32(h.month) == 12 && Convert.ToInt32(h.day) <= 23))
                    {
                        h.horoSlavs = "Ваш покровитель - Карачун. Покровитель мороза, холода и мрака";
                    }
                }
                if (h.year == "" || !int.TryParse(h.year, out forParse))
                {
                    h.horoJapan = "Невозможно определить знак по Японскому календарю!";
                }
                else
                {
                    string[] signs = { "Крыса", "Бык", "Тигр", "Кролик", "Дракон", "Змея", "Лошадь", "Овца", "Обезьяна", "Петух", "Собака", "Кабан" };

                    int a;
                    int sign = 0;
                    if (Convert.ToInt32(h.year) >= 1900)
                    {
                        a = 1899;
                        while (a < Convert.ToInt32(h.year))
                        {
                            for (int j = 0; j < 12 && a < Convert.ToInt32(h.year); j++)
                            {
                                a++;
                                sign = j;
                            }
                        }
                    }
                    else if (Convert.ToInt32(h.year) < 1900)
                    {
                        a = 1900;
                        while (a > Convert.ToInt32(h.year))
                        {
                            for (int j = 11; j >= 0 && a > Convert.ToInt32(h.year); j--)
                            {
                                a--;
                                sign = j;
                            }
                        }
                    }
                    switch (sign)
                    {
                        case 0:
                            h.horoJapan = "Крыса";
                            break;
                        case 1:
                            h.horoJapan = "Бык";
                            break;
                        case 2:
                            h.horoJapan = "Тигр";
                            break;
                        case 3:
                            h.horoJapan = "Кролик";
                            break;
                        case 4:
                            h.horoJapan = "Дракон";
                            break;
                        case 5:
                            h.horoJapan = "Змея";
                            break;
                        case 6:
                            h.horoJapan = "Лошадь";
                            break;
                        case 7:
                            h.horoJapan = "Овца";
                            break;
                        case 8:
                            h.horoJapan = "Обезьяна";
                            break;
                        case 9:
                            h.horoJapan = "Петух";
                            break;
                        case 10:
                            h.horoJapan = "Собака";
                            break;
                        case 11:
                            h.horoJapan = "Кабан";
                            break;
                    }
                }
                L[i] = h;
            }
        }

        static void Main(string[] args)
        {
            List<Horoscope> Horoscope = new List<Horoscope>();
            getData("horoscopeSlavic.csv", Horoscope);
            check(Horoscope);
            printData(Horoscope);
            Console.WriteLine();
            createFile("Horoscope.csv", Horoscope);
        }



    }

}

