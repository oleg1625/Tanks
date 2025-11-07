using Play.Maps;
using Play.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Play
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Расцветка консоли
            Console.ForegroundColor = ConsoleColor.Green;

            //Старт игры
            Start();
            Loading(5000);

            // Инициализация переменных
            int tank_selection;
            int map_selection = 0;
            int line_selection = 0;
            bool trigger1 = true;
            bool trigger2 = true;
            Tank TankPlayer = null;
            Map MapPlayer = null;
            
            //Выбор танка
            Console.Write("Здраствуйте, дорогой игрок. \nТанки на выбор: \n 1. Panther D \n 2. T34-85 \n 3. M4 Sherman \n\nВыберите технику: ");

            while (trigger1)
            {
                tank_selection = Convert.ToInt32(Console.ReadLine());
                switch (tank_selection)
                {
                    case 1:
                        TankPlayer = new Panther_D();
                        trigger1 = false;
                        break;
                    case 2:
                        TankPlayer = new T34_85();
                        trigger1 = false;
                        break;
                    case 3:
                        TankPlayer = new M4_Sherman();
                        trigger1 = false;
                        break;
                    default:
                        Console.Write("Некорректный ввод. Выберите ещё раз: ");
                        break;


                }
            }

            Console.WriteLine();
            
            if (TankPlayer != null) 
            {
                Console.WriteLine($"Вы выбрали {TankPlayer.Name}\nХарактеристики:\n Здоровье - {TankPlayer.HP}\n Урон - {TankPlayer.Damage}\n");
            }
            Enter();
            Loading(2000);

            //Выбор карты
            Console.Write("Карты: \n 1.Берлин \n\nВыберите карту: ");

            while (trigger2)
            {
                map_selection = Convert.ToInt32(Console.ReadLine());

                switch (map_selection) 
                {
                    case 1:
                        MapPlayer = new Berlin();
                        trigger2 = false;
                        break;
                    default:
                        Console.Write("Некорректный ввод. Выберите ещё раз: ");
                        break;
                }
            }
            Loading(3000);
            Console.WriteLine();

            // Подготовка к катке
            if (map_selection == 1)
            {
                line_selection = Line_selection(MapPlayer);
                Loading(1000);
                Game_Information(TankPlayer, MapPlayer, line_selection);
                Enter();

                switch (line_selection) 
                {
                    case 1:
                        EventBerlin1(TankPlayer);
                        break;
                }
            }


            //Расцветка консоли
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();


        }

        // Системные методы
        public static void Start()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Пивной Клондайк Продакшн представляет");
            Thread.Sleep(5000);
            Console.Clear();
            Thread.Sleep(5000);
            Console.WriteLine("От создателей Стёп, подкинь на пиво");
            Thread.Sleep(5000);
            Console.Clear();
            Thread.Sleep(5000);
            Console.WriteLine("При финансовой подержки Стёпы");
            Thread.Sleep(5000);
            Console.Clear();
            Thread.Sleep(5000);
            Console.WriteLine("Пивные Танки");
            Thread.Sleep(5000);
            Console.Clear();
        }
        public static int Line_selection(Map map) 
        {
            Console.Write($"Вы выбрали карту {map.Name}, линий на этой карте {map.Count_Lines}. \nВыберите на какой линии вы будете играть: ");

            while(true) 
            {
                int selection_player = Convert.ToInt32(Console.ReadLine());

                if(selection_player > 0 && selection_player <= map.Count_Lines) 
                {
                    return selection_player;
                }

                Console.Write("Некорректный ввод. Выберите ещё раз: ");
            }
        }
        public static void Loading(int time) 
        {
            Console.Clear();
            Thread.Sleep(1000);
            Console.WriteLine("Загрузка");
            Thread.Sleep(time);
            Console.Clear();
        }
        public static void Enter() 
        {
            Console.WriteLine("Нажмите Enter чтобы продолжить");
            Console.ReadLine();
            Console.Clear();
        }
        public static void Game_Information(Tank tank, Map map, int line) 
        {
            Console.WriteLine($"Танк: {tank.Name}\nХарактеристики:\n Здоровье - {tank.HP}\n Урон - {tank.Damage}\nКарта: {map.Name}\nЛиния: {line}");
        }

        //Игровой процесс

        //События Берлина
        public static void EventBerlin1(Tank tank) 
        {
            
        }

    }


    //Папки
    namespace Tanks
    {
        public abstract class Tank
        {
            public abstract string Name { get; set;  }
            public abstract int HP { get; protected set; }
            public abstract int Damage { get; protected set; }
            public abstract bool Engine_Сondition { get; protected set; }

            public void Shot(Tank a, int damage) 
            {
                a.HP -= damage;
            }

        }
    

        public class T34_85 : Tank
        {
            private string _name = "T34-85";
            private int _hp = 100;
            private int _damage = 15;
            private bool _engine_condition = false;

            public override string Name 
            {
                get => _name;
                set => _name = value;
            }

            public override int HP 
            { 
                get => _hp; 
                protected set 
                {
                    _hp = value;        
                } 
            }

            public override int Damage 
            {
                get => _damage;
                protected set 
                {
                    _damage = value;
                }
            }
            public override bool Engine_Сondition 
            {
                get => _engine_condition;
                protected set => _engine_condition = value;
            }

        }
        public class Panther_D : Tank
        {
            private string _name = "Panther D";
            private int _hp = 120;
            private int _damage = 25;
            private bool _engine_condition = false;

            public override string Name
            {
                get => _name;
                set => _name = value;
            }

            public override int HP
            {
                get => _hp;
                protected set
                {
                    _hp = value;
                }
            }

            public override int Damage
            {
                get => _damage;
                protected set
                {
                    _damage = value;
                }
            }

            public override bool Engine_Сondition
            {
                get => _engine_condition;
                protected set => _engine_condition = value;
            }

        }
        public class M4_Sherman : Tank
        {
            private string _name = "M4 Sherman";
            private int _hp = 140;
            private int _damage = 10;
            private bool _engine_condition = false;

            public override string Name
            {
                get => _name;
                set => _name = value;
            }

            public override int HP
            {
                get => _hp;
                protected set
                {
                    _hp = value;
                }
            }

            public override int Damage
            {
                get => _damage;
                protected set
                {
                    _damage = value;
                }
            }

            public override bool Engine_Сondition
            {
                get => _engine_condition;
                protected set => _engine_condition = value;
            }

        }

    }

    namespace Maps
    {
        public abstract class Map 
        {
            public abstract string Name { get; set; }

            public abstract int Count_Lines { get; set; }
        }

        public class Berlin : Map 
        {
            private string _name = "Берлин";
            private int _count_lines = 3;

            public override string Name 
            {
                get => _name;
                set => _name = value;
            }
            public override int Count_Lines 
            { 
                get => _count_lines; 
                set => _count_lines = value; 
            }
        }
    }
}