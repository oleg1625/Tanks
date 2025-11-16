using Play.Maps;
using Play.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

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

            // Подготовка к катке
            if (map_selection == 1)
            {
                line_selection = Line_selection(MapPlayer);
                Loading(1000);
                Game_Information(TankPlayer, MapPlayer, line_selection);
                Enter();
                Loading(1000);

                switch (line_selection)
                {
                    case 1:
                        if (MapPlayer.Name == "Берлин")
                        {
                            EventBerlin1(TankPlayer);
                        }
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

            while (true)
            {
                int selection_player = Convert.ToInt32(Console.ReadLine());

                if (selection_player > 0 && selection_player <= map.Count_Lines)
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
        public static void Mini_Game_Information(Tank tank)
        {
            Console.WriteLine($"Танк: {tank.Name}\nХарактеристики:\n Здоровье - {tank.HP}\n Урон - {tank.Damage}\n Состояния двигателя - {tank.Engine_Сondition}");
        }

        // Управление танка
        public static void Start_Tank(Tank tank)
        {
            Random random = new Random();
            int trigger = random.Next(1, 5);
            int selection = 0;
            int count_selection = 0;

            Console.WriteLine("Заведите двикатель:\n 1.Вкл. Двигатель\n 2.Стоять на месте\n 3. Характеристики");

            while (true)
            {
                Console.Write("Выбор: ");
                selection = Convert.ToInt32(Console.ReadLine());

                if (selection == 1)
                {
                    tank.Turn_On_The_Engine(tank);
                    Console.WriteLine("Двигатель заведен.");
                    break;
                }
                else if (selection == 2)
                {
                    Console.WriteLine("Вы стоите на месте.");
                    count_selection++;
                    if (count_selection == trigger)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("С неба привет!");
                        Thread.Sleep(1000);
                        Console.WriteLine("Игра окончена");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }
                }
                else if (selection == 3)
                {
                    Mini_Game_Information(tank);
                }
                else
                {
                    Console.Write("Некорректный ввод, ведите ещё раз: ");
                }

            }

            Console.WriteLine();
        }

        // Боевые действия
        static void Point_A_Berlin_Tank_Battle(Tank tank)
        {
            Random rand = new Random();
            int count_tanks = rand.Next(1, 3);
            Tank enemy_tank1 = null;
            Tank enemy_tank2 = null;

            if (count_tanks == 1)
            {
                enemy_tank1 = new Marder_II();
                int shot_chance = rand.Next(1, 3);

                Console.WriteLine($"Нас вас выехал {enemy_tank1.Name}");
                Console.WriteLine();
                Thread.Sleep(1000);
                if (shot_chance == 1)
                {
                    enemy_tank1.Shot(tank, enemy_tank1.Damage);
                    Console.WriteLine($"По вам был произведен выстирел\nВаше здоровье: {tank.HP}");
                }
                while (enemy_tank1.HP != 0)
                {
                    if(tank.HP == 0) 
                    {
                        Console.WriteLine($"{tank.Name} уничтожен!");
                        Environment.Exit(0);
                    }

                    int selection_battle = 0;
                    Console.WriteLine();
                    Console.Write("Ваши действия:\n 1.Открыть огонь\n 2.Отступить\n 3.Просмотреть характеристики\nВыбор: ");

                    selection_battle = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    if (selection_battle == 1)
                    {
                        Console.WriteLine("Выстерл!");
                        Console.WriteLine();
                        tank.Shot(enemy_tank1, tank.Damage);

                        Thread.Sleep(1000);

                        shot_chance = rand.Next(1, 3);

                        if (shot_chance == 1)
                        {
                            enemy_tank1.Shot(tank, enemy_tank1.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy_tank1.Name}.");
                        }


                    }
                    if (selection_battle == 2)
                    {
                        Console.WriteLine($"Вы отступили.{tank.Name} выжил. Задача не выполнена.");
                        Environment.Exit(0);
                    }
                    if (selection_battle == 3)
                    {
                        Mini_Game_Information(tank);
                        Console.WriteLine();
                    }
                }



            }

            if (count_tanks == 2)
            {
                enemy_tank1 = new Marder_II();
                enemy_tank2 = new Pz_Kpfw_III();

                int shot_chance = rand.Next(1, 3);

                Console.WriteLine($"Нас вас выехал {enemy_tank1.Name} и {enemy_tank2.Name}");
                Console.WriteLine();
                Thread.Sleep(1000);
                if (shot_chance == 1)
                {
                    enemy_tank1.Shot(tank, enemy_tank1.Damage);
                    Console.WriteLine($"По вам был произведен выстирел\nВаше здоровье: {tank.HP}");
                }
                while (enemy_tank1.HP != 0 && enemy_tank2.HP != 0)
                {
                    if (tank.HP == 0)
                    {
                        Console.WriteLine($"{tank.Name} уничтожен!");
                        Environment.Exit(0);
                    }

                    int selection_battle = 0;
                    Console.WriteLine();
                    Console.Write($"Ваши действия:\n 1.Открыть огонь по {enemy_tank1.Name}\n 2.Открыть огонь по {enemy_tank2.Name}\n 3.Отступить\n 4.просмотреть характеристики\nВыбор: ");

                    selection_battle = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    if (selection_battle == 1)
                    {
                        Console.WriteLine("Выстерл!");
                        Console.WriteLine();
                        tank.Shot(enemy_tank1, tank.Damage);

                        Thread.Sleep(1000);

                        shot_chance = rand.Next(1, 5);

                        if (shot_chance == 1)
                        {
                            enemy_tank1.Shot(tank, enemy_tank1.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy_tank1.Name}.");
                        }
                        if (shot_chance == 2)
                        {
                            enemy_tank1.Shot(tank, enemy_tank2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy_tank2.Name}.");
                        }
                        if (shot_chance == 3)
                        {
                            enemy_tank1.Shot(tank, enemy_tank1.Damage);
                            enemy_tank1.Shot(tank, enemy_tank2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy_tank1.Name} и {enemy_tank1.Name}.");
                        }


                    }
                    if (selection_battle == 2)
                    {
                        Console.WriteLine("Выстерл!");
                        Console.WriteLine();
                        tank.Shot(enemy_tank2, tank.Damage);

                        Thread.Sleep(1000);

                        shot_chance = rand.Next(1, 5);

                        if (shot_chance == 1)
                        {
                            enemy_tank1.Shot(tank, enemy_tank1.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy_tank1.Name}.");
                        }
                        if (shot_chance == 2)
                        {
                            enemy_tank1.Shot(tank, enemy_tank2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy_tank2.Name}.");
                        }
                        if (shot_chance == 3)
                        {
                            enemy_tank1.Shot(tank, enemy_tank1.Damage);
                            enemy_tank1.Shot(tank, enemy_tank2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy_tank1.Name} и {enemy_tank1.Name}.");
                        }


                    }
                    if (selection_battle == 3)
                    {
                        Console.WriteLine($"Вы отступили.{tank.Name} выжил. Задача не выполнена.");
                        Environment.Exit(0);
                    }
                    if (selection_battle == 4)
                    {
                        Mini_Game_Information(tank);
                        Console.WriteLine();
                    }
                }                
            }

            Console.WriteLine("Танки противника был уничтожены, задание выполнено!");
        }
        // Карта Берлина
        static void EventBerlin1(Tank tank)
        {
            Console.WriteLine("Игра началась! Задача захватить точку А");
            Start_Tank(tank);
            Thread.Sleep(1000);
            Console.WriteLine("Вы едите к точке A.");
            Thread.Sleep(1000);
            Point_A_Berlin_Tank_Battle(tank);
        }
    }
    


    //Папки
    namespace Tanks
    {
        public abstract class Tank
        {
            public abstract string Name { get; set; }
            public abstract int HP { get; protected set; }
            public abstract int Damage { get; protected set; }
            public abstract bool Engine_Сondition { get; protected set; }

            public void Shot(Tank a, int damage)
            {
                a.HP -= damage;
            }
            public void Turn_On_The_Engine(Tank a)
            {
                a.Engine_Сondition = true;
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
                    if (value < 0) 
                    {
                        _hp = 0;
                    }
                    else 
                    {
                        _hp = value;
                    }
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
                    if (value < 0)
                    {
                        _hp = 0;
                    }
                    else
                    {
                        _hp = value;
                    }
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
                    if (value < 0)
                    {
                        _hp = 0;
                    }
                    else
                    {
                        _hp = value;
                    }
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
        public class Marder_II : Tank 
        {
            private string _name = "Marder II";
            private int _hp = 25;
            private int _damage = 40;
            private bool _engine_condition = true;

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
                    if (value < 0)
                    {
                        _hp = 0;
                    }
                    else
                    {
                        _hp = value;
                    }
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
        public class Pz_Kpfw_III : Tank
        {
            private string _name = "Pz.Kpfw. III ";
            private int _hp = 35;
            private int _damage = 5;
            private bool _engine_condition = true;

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
                    if (value < 0)
                    {
                        _hp = 0;
                    }
                    else
                    {
                        _hp = value;
                    }
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