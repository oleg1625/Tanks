using Play.Maps;
using Play.Tanks;
using Play.Enemys;
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
                    case 2:
                        if (MapPlayer.Name == "Берлин")
                        {
                            EventBerlin2(TankPlayer);
                        }
                        break;
                    case 3:
                        if (MapPlayer.Name == "Берлин")
                        {
                            EventBerlin3(TankPlayer);
                        }
                        break;
                }
            }
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

            Console.WriteLine("Заведите двикатель:\n 1.Вкл. Двигатель\n 2.Стоять на месте\n 3.Характеристики");

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
                    enemy_tank1.Shot_on_Tank(tank, enemy_tank1.Damage);
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
                        tank.Shot_on_Tank(enemy_tank1, tank.Damage);

                        Thread.Sleep(1000);

                        if (enemy_tank1.HP == 0)
                        {
                            Console.WriteLine($"{enemy_tank1.Name} - уничтожен");
                        }
                        else
                        {
                            enemy_tank1.Shot_on_Tank(tank, enemy_tank1.Damage);
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

                    if (enemy_tank1.HP == 0) 
                    {
                        Console.WriteLine($"{enemy_tank1.Name} уничтожен!");
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
                    enemy_tank1.Shot_on_Tank(tank, enemy_tank1.Damage);
                    Console.WriteLine($"По вам был произведен выстрел\nВаше здоровье: {tank.HP}");
                }
                while (enemy_tank1.HP != 0 || enemy_tank2.HP != 0)
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
                        tank.Shot_on_Tank(enemy_tank1, tank.Damage);

                        Thread.Sleep(1000);

                        if (enemy_tank1.HP == 0)
                        {
                            Console.WriteLine($"{enemy_tank1.Name} - уничтожен");
                        }

                        Thread.Sleep(1000);

                        if (enemy_tank1.HP != 0 && enemy_tank2.HP != 0)
                        {
                            enemy_tank1.Shot_on_Tank(tank, enemy_tank1.Damage);
                            enemy_tank1.Shot_on_Tank(tank, enemy_tank2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy_tank1.Name} и {enemy_tank2.Name}.");
                        }
                        else if (enemy_tank1.HP != 0) 
                        {
                            enemy_tank1.Shot_on_Tank(tank, enemy_tank1.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy_tank1.Name}.");
                        }
                        else if(enemy_tank2.HP != 0) 
                        {
                            enemy_tank1.Shot_on_Tank(tank, enemy_tank2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy_tank2.Name}.");
                        }


                    }
                    if (selection_battle == 2)
                    {
                        Console.WriteLine("Выстерл!");
                        Console.WriteLine();
                        tank.Shot_on_Tank(enemy_tank2, tank.Damage);

                        Thread.Sleep(1000);

                        if (enemy_tank2.HP == 0)
                        {
                            Console.WriteLine($"{enemy_tank2.Name} - уничтожен");
                        }

                        Thread.Sleep(1000);

                        if (enemy_tank1.HP != 0 && enemy_tank2.HP != 0)
                        {
                            enemy_tank1.Shot_on_Tank(tank, enemy_tank1.Damage);
                            enemy_tank1.Shot_on_Tank(tank, enemy_tank2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy_tank1.Name} и {enemy_tank2.Name}.");
                        }
                        else if (enemy_tank1.HP != 0)
                        {
                            enemy_tank1.Shot_on_Tank(tank, enemy_tank1.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy_tank1.Name}.");
                        }
                        else if (enemy_tank2.HP != 0)
                        {
                            enemy_tank1.Shot_on_Tank(tank, enemy_tank2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy_tank2.Name}.");
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

                    if (enemy_tank1.HP == 0)
                    {
                        Console.WriteLine($"{enemy_tank1.Name} уничтожен!");
                    }
                    if (enemy_tank2.HP == 0)
                    {
                        Console.WriteLine($"{enemy_tank2.Name} уничтожен!");
                    }
                }                
            }

            Console.WriteLine("Танки противника были уничтожены, задание выполнено!");
        }
        static void Point_B_Berlin_Tank_Battle(Tank tank) 
        {
            Random rand = new Random();
            int number_of_combat_forces = rand.Next(1, 5);
            Enemy enemy1 = null;
            Enemy enemy2 = null;
            Enemy enemy3 = null;
            Enemy enemy4 = null;

            if(number_of_combat_forces == 1) 
            {
                enemy1 = new Platoon_Of_Stormtroopers();
                enemy2 = new Howitzer();
                int selection_battle;

                Console.WriteLine($"Вы едите по кварталу, командир заметил {enemy1.Name}");
                Thread.Sleep(1000);
                tank.Shot_on_Tank(tank, enemy2.Damage);
                Console.WriteLine($"Из угла по вам выстрелела {enemy2.Name}.\nВаше здоровья: {tank.HP}");
                Thread.Sleep(1000);

                while (enemy1.HP != 0 || enemy2.HP != 0) 
                {                    
                    if (tank.HP == 0)
                    {
                        Console.WriteLine($"{tank.Name} уничтожен!");
                        Environment.Exit(0);
                    }

                    Console.WriteLine();
                    Console.Write($"Ваши действия:\n 1.Открыть огонь по {enemy1.Name}\n 2.Открыть огонь по {enemy2.Name}\n 3.Отступить\n 4.Просмотреть характеристики\nВыбор: ");
                    selection_battle = Convert.ToInt32(Console.ReadLine());

                    if (selection_battle == 1) 
                    {
                        Console.WriteLine("Выстерл!");
                        Console.WriteLine();
                        enemy1.Shot_on_Enemy(enemy1, tank.Damage);

                        Thread.Sleep(1000);

                        if (enemy1.HP == 0)
                        {
                            Console.WriteLine($"{enemy1.Name} - уничтожен");
                        }

                        Thread.Sleep(1000);

                        if (enemy1.HP != 0 && enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name} и {enemy2.Name}.");
                        }
                        else if (enemy1.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name}.");
                        }
                        else if (enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy2.Name}.");
                        }
                    }
                    if (selection_battle == 2) 
                    {
                        Console.WriteLine("Выстерл!");
                        Console.WriteLine();
                        enemy2.Shot_on_Enemy(enemy2, tank.Damage);

                        Thread.Sleep(1000);

                        if (enemy2.HP == 0)
                        {
                            Console.WriteLine($"{enemy2.Name} - уничтожен");
                        }

                        Thread.Sleep(1000);

                        if (enemy1.HP != 0 && enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name} и {enemy2.Name}.");
                        }
                        else if (enemy1.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name}.");
                        }
                        else if (enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy2.Name}.");
                        }
                    }
                    if(selection_battle == 3) 
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
                Console.WriteLine("Противники были уничтожены, задание выполнено!");
            }
            if(number_of_combat_forces == 2) 
            {
                enemy1 = new Platoon_Of_Stormtroopers();
                enemy2 = new Platoon_Of_Grenadiers();
                int selection_battle;

                Console.WriteLine($"Вы едите по кварталу, командир заметил {enemy1.Name} и {enemy2.Name}");
                Thread.Sleep(1000);

                while (enemy1.HP != 0 || enemy2.HP != 0) 
                {
                    if (tank.HP == 0)
                    {
                        Console.WriteLine($"{tank.Name} уничтожен!");
                        Environment.Exit(0);
                    }

                    Console.WriteLine();
                    Console.Write($"Ваши действия:\n 1.Открыть огонь по {enemy1.Name}\n 2.Открыть огонь по {enemy2.Name}\n 3.Отступить\n 4.Просмотреть характеристики\nВыбор: ");
                    selection_battle = Convert.ToInt32(Console.ReadLine());

                    if (selection_battle == 1)
                    {
                        Console.WriteLine("Выстерл!");
                        Console.WriteLine();
                        enemy1.Shot_on_Enemy(enemy1, tank.Damage);

                        Thread.Sleep(1000);

                        if (enemy1.HP == 0)
                        {
                            Console.WriteLine($"{enemy1.Name} - уничтожен");
                        }

                        Thread.Sleep(1000);

                        if (enemy1.HP != 0 && enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name} и {enemy2.Name}.");
                        }
                        else if (enemy1.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name}.");
                        }
                        else if (enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy2.Name}.");
                        }
                    }
                    if (selection_battle == 2)
                    {
                        Console.WriteLine("Выстерл!");
                        Console.WriteLine();
                        enemy2.Shot_on_Enemy(enemy2, tank.Damage);

                        Thread.Sleep(1000);

                        if (enemy2.HP == 0)
                        {
                            Console.WriteLine($"{enemy2.Name} - уничтожен");
                        }

                        Thread.Sleep(1000);

                        if (enemy1.HP != 0 && enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name} и {enemy2.Name}.");
                        }
                        else if (enemy1.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name}.");
                        }
                        else if (enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy2.Name}.");
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
                Console.WriteLine("Противники были уничтожены, задание выполнено!");
            }
            if (number_of_combat_forces == 3) 
            {
                enemy1 = new Platoon_Of_Stormtroopers();
                enemy2 = new Howitzer();
                enemy3 = new Platoon_Of_Grenadiers();
                int selection_battle;

                Console.WriteLine($"Вы едите по кварталу, командир заметил {enemy1.Name} и {enemy3.Name}");
                Thread.Sleep(1000);
                tank.Shot_on_Tank(tank, enemy2.Damage);
                Console.WriteLine($"Из угла по вам выстрелела {enemy2.Name}.\nВаше здоровья: {tank.HP}");
                Thread.Sleep(1000);

                while (enemy1.HP != 0 || enemy2.HP != 0 || enemy3.HP != 0) 
                {
                    if (tank.HP == 0)
                    {
                        Console.WriteLine($"{tank.Name} уничтожен!");
                        Environment.Exit(0);
                    }

                    Console.WriteLine();
                    Console.Write($"Ваши действия:\n 1.Открыть огонь по {enemy1.Name}\n 2.Открыть огонь по {enemy2.Name}\n 3.Открыть огонь по {enemy3.Name}\n 4.Отступить\n 5.Просмотреть характеристики\nВыбор: ");
                    selection_battle = Convert.ToInt32(Console.ReadLine());

                    if (selection_battle == 1)
                    {
                        Console.WriteLine("Выстерл!");
                        Console.WriteLine();
                        enemy1.Shot_on_Enemy(enemy1, tank.Damage);

                        Thread.Sleep(1000);

                        if (enemy1.HP == 0)
                        {
                            Console.WriteLine($"{enemy1.Name} - уничтожен");
                        }

                        Thread.Sleep(1000);

                        if (enemy1.HP != 0 && enemy2.HP != 0 && enemy3.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            tank.Shot_on_Tank(tank, enemy3.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name}, {enemy2.Name} и {enemy3.Name}.");
                        }
                        else if (enemy1.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name}.");
                        }
                        else if (enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy2.Name}.");
                        }
                        else if (enemy3.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy3.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy2.Name}.");
                        }
                        else if (enemy1.HP != 0 && enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name} и {enemy2.Name}.");
                        }
                        else if (enemy1.HP != 0 && enemy3.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            tank.Shot_on_Tank(tank, enemy3.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name} и {enemy3.Name}.");
                        }
                        else if (enemy3.HP != 0 && enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy3.Damage);
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy3.Name} и {enemy2.Name}.");
                        }

                    }
                    if (selection_battle == 2)
                    {
                        Console.WriteLine("Выстерл!");
                        Console.WriteLine();
                        enemy2.Shot_on_Enemy(enemy2, tank.Damage);

                        Thread.Sleep(1000);

                        if (enemy2.HP == 0)
                        {
                            Console.WriteLine($"{enemy2.Name} - уничтожен");
                        }

                        Thread.Sleep(1000);

                        if (enemy1.HP != 0 && enemy2.HP != 0 && enemy3.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            tank.Shot_on_Tank(tank, enemy3.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name}, {enemy2.Name} и {enemy3.Name}.");
                        }
                        else if (enemy1.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name}.");
                        }
                        else if (enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy2.Name}.");
                        }
                        else if (enemy3.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy3.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy2.Name}.");
                        }
                        else if (enemy1.HP != 0 && enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name} и {enemy2.Name}.");
                        }
                        else if (enemy1.HP != 0 && enemy3.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            tank.Shot_on_Tank(tank, enemy3.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name} и {enemy3.Name}.");
                        }
                        else if (enemy3.HP != 0 && enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy3.Damage);
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy3.Name} и {enemy2.Name}.");
                        }

                    }
                    if (selection_battle == 3)
                    {
                        Console.WriteLine("Выстерл!");
                        Console.WriteLine();
                        enemy3.Shot_on_Enemy(enemy3, tank.Damage);

                        Thread.Sleep(1000);

                        if (enemy3.HP == 0)
                        {
                            Console.WriteLine($"{enemy3.Name} - уничтожен");
                        }

                        Thread.Sleep(1000);

                        if (enemy1.HP != 0 && enemy2.HP != 0 && enemy3.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            tank.Shot_on_Tank(tank, enemy3.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name}, {enemy2.Name} и {enemy3.Name}.");
                        }
                        else if (enemy1.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name}.");
                        }
                        else if (enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy2.Name}.");
                        }
                        else if (enemy3.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy3.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy2.Name}.");
                        }
                        else if (enemy1.HP != 0 && enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name} и {enemy2.Name}.");
                        }
                        else if (enemy1.HP != 0 && enemy3.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            tank.Shot_on_Tank(tank, enemy3.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name} и {enemy3.Name}.");
                        }
                        else if (enemy3.HP != 0 && enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy3.Damage);
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy3.Name} и {enemy2.Name}.");
                        }

                    }
                    if (selection_battle == 4)
                    {
                        Console.WriteLine($"Вы отступили.{tank.Name} выжил. Задача не выполнена.");
                        Environment.Exit(0);
                    }
                    if (selection_battle == 5)
                    {
                        Mini_Game_Information(tank);
                        Console.WriteLine();
                    }

                }
                Console.WriteLine("Противники были уничтожены, задание выполнено!");
            }
            if(number_of_combat_forces == 4) 
            {
                enemy1 = new Platoon_Of_Stormtroopers();
                enemy2 = new Howitzer();
                enemy3 = new Platoon_Of_Grenadiers();
                enemy4 = new Platoon_Of_Grenadiers();
                int selection_battle;

                Console.WriteLine($"Вы едите по кварталу, командир заметил {enemy1.Name} и {enemy3.Name}");
                Thread.Sleep(1000);
                tank.Shot_on_Tank(tank, enemy2.Damage);
                Console.WriteLine($"Из угла по вам выстрелела {enemy2.Name}.\nВаше здоровья: {tank.HP}");
                Thread.Sleep(1000);

                while (enemy1.HP != 0 || enemy2.HP != 0 || enemy3.HP != 0 || enemy4.HP != 0) 
                {
                    if (tank.HP == 0)
                    {
                        Console.WriteLine($"{tank.Name} уничтожен!");
                        Environment.Exit(0);
                    }

                    Console.WriteLine();
                    Console.Write($"Ваши действия:\n 1.Открыть огонь по {enemy1.Name}\n 2.Открыть огонь по {enemy2.Name}\n 3.Открыть огонь по {enemy3.Name}\n 4.Открыть огонь по {enemy4.Name}\n 5.Отступить\n 6.Просмотреть характеристики\nВыбор: ");
                    selection_battle = Convert.ToInt32(Console.ReadLine());

                    if (selection_battle == 1) 
                    {
                        Console.WriteLine("Выстерл!");
                        Console.WriteLine();
                        enemy1.Shot_on_Enemy(enemy1, tank.Damage);

                        Thread.Sleep(1000);

                        if (enemy1.HP == 0) 
                        {
                            Console.WriteLine($"{enemy1.Name} - уничтожен");
                        }

                        Thread.Sleep(1000);

                        if(enemy1.HP != 0) 
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name}.");
                        }
                        if (enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy2.Name}.");
                        }
                        if (enemy3.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy3.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy3.Name}.");
                        }
                        if (enemy4.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy4.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy4.Name}.");
                        }
                    }
                    if (selection_battle == 2)
                    {
                        Console.WriteLine("Выстерл!");
                        Console.WriteLine();
                        enemy2.Shot_on_Enemy(enemy2, tank.Damage);

                        Thread.Sleep(1000);

                        if (enemy2.HP == 0)
                        {
                            Console.WriteLine($"{enemy2.Name} - уничтожен");
                        }

                        Thread.Sleep(1000);

                        if (enemy1.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name}.");
                        }
                        if (enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy2.Name}.");
                        }
                        if (enemy3.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy3.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy3.Name}.");
                        }
                        if (enemy4.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy4.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy4.Name}.");
                        }
                    }
                    if (selection_battle == 3)
                    {
                        Console.WriteLine("Выстерл!");
                        Console.WriteLine();
                        enemy3.Shot_on_Enemy(enemy3, tank.Damage);

                        Thread.Sleep(1000);

                        if (enemy3.HP == 0)
                        {
                            Console.WriteLine($"{enemy3.Name} - уничтожен");
                        }

                        Thread.Sleep(1000);

                        if (enemy1.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name}.");
                        }
                        if (enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy2.Name}.");
                        }
                        if (enemy3.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy3.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy3.Name}.");
                        }
                        if (enemy4.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy4.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy4.Name}.");
                        }
                    }
                    if (selection_battle == 4)
                    {
                        Console.WriteLine("Выстерл!");
                        Console.WriteLine();
                        enemy4.Shot_on_Enemy(enemy4, tank.Damage);

                        Thread.Sleep(1000);

                        if (enemy4.HP == 0)
                        {
                            Console.WriteLine($"{enemy4.Name} - уничтожен");
                        }

                        Thread.Sleep(1000);

                        if (enemy1.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy1.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy1.Name}.");
                        }
                        if (enemy2.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy2.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy2.Name}.");
                        }
                        if (enemy3.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy3.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy3.Name}.");
                        }
                        if (enemy4.HP != 0)
                        {
                            tank.Shot_on_Tank(tank, enemy4.Damage);
                            Console.WriteLine($"По вам был призведен выстрел от {enemy4.Name}.");
                        }
                    }
                    if (selection_battle == 5)
                    {
                        Console.WriteLine($"Вы отступили.{tank.Name} выжил. Задача не выполнена.");
                        Environment.Exit(0);
                    }
                    if (selection_battle == 6)
                    {
                        Mini_Game_Information(tank);
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("Противники были уничтожены, задание выполнено!");
            }                       
        }
        static void Point_C_Berlin_Tank_Battle(Tank tank) 
        {
            Random rand = new Random();
            int selection_player;

            Console.WriteLine("Проезжая по переулку, командир увидел подлетающий бомбардировщик.");
            Console.WriteLine("Ваши действия:\n 1.Заехать за храм\n 2.Поехать дальше по переулку");
            Console.Write("Выбор: ");
            selection_player = Convert.ToInt32(Console.ReadLine());

            if(selection_player == 1) 
            {
                tank.Shot_on_Tank(tank, 40);
                Console.WriteLine($"Продьезжая, вы наткнулись на мину, ваше здоровье: {tank.HP}");

                if (tank.HP == 0)
                {
                    Console.WriteLine($"{tank.Name} уничтожен!");
                    Environment.Exit(0);
                }

                Console.WriteLine("Самолет пролетел мимо, вы дальше продолжаете продвигаться к точке.");
                Console.WriteLine("Ваши действия:\n 1.Проехать по бульвару\n 2.Сделать крюк");
                Console.Write("Выбор: ");
                selection_player = Convert.ToInt32(Console.ReadLine());

                if (selection_player == 1) 
                {
                    Tank enemy_tank = new Marder_II();
                    bool tank_on_C1 = false;
                    bool tank_on_C2 = false;

                    tank.Shot_on_Tank(tank, enemy_tank.Damage);
                    tank.Turn_Off_The_Engine(tank);
                    Console.WriteLine($"Проезжая, по бульвару вы наткнулись на {enemy_tank.Name}\nПо вам был сделан выстрел, двигатель заглушен.");
                    Console.WriteLine("До точки осталось совсем чуть-чуть.");
                    Console.WriteLine();

                    while (tank_on_C1 == false || tank_on_C2 == false) 
                    {
                        if (tank.HP == 0)
                        {
                            Console.WriteLine($"{tank.Name} уничтожен!");
                            Environment.Exit(0);
                        }

                        Console.Write($"Ваши действия:\n 1.Восстановить двигатель\n 2.Выстрел по {enemy_tank.Name}\n 3.Просмотреть характеристики\nВыбор: ");
                        selection_player = Convert.ToInt32(Console.ReadLine());

                        if (selection_player == 1) 
                        {
                            tank.Turn_On_The_Engine(tank);
                            Console.WriteLine("Двигатель востановлен, можно ехать.");

                            if(enemy_tank.HP != 0) 
                            {
                                tank.Shot_on_Tank(tank, enemy_tank.Damage);
                                Console.WriteLine($"По вам был призведен выстрел от {enemy_tank.Name}.");
                            }                                                       
                        }

                        if(selection_player == 2) 
                        {
                            Console.WriteLine("Выстерл!");
                            Console.WriteLine();
                            tank.Shot_on_Tank(enemy_tank, tank.Damage);

                            Thread.Sleep(1000);

                            if (enemy_tank.HP == 0)
                            {
                                Console.WriteLine($"{enemy_tank.Name} - уничтожен");
                            }
                            if (enemy_tank.HP != 0)
                            {
                                tank.Shot_on_Tank(tank, enemy_tank.Damage);
                                Console.WriteLine($"По вам был призведен выстрел от {enemy_tank.Name}.");
                            }
                        }
                    }
                    Console.WriteLine("Вы добрались на точкке С.");
                }
                if(selection_player == 2) 
                {
                    Console.WriteLine("Сделав крюк, вы добрвлись до точки С.");
                }
            }
            if (selection_player == 2) 
            {
                Console.WriteLine("Поехав дальше по преркеулку, бомбардировщик уничтожил ваш танк.");
                Environment.Exit(0);
            }
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
        static void EventBerlin2(Tank tank)
        {
            Console.WriteLine("Игра началась! Задача захватить точку Б");
            Start_Tank(tank);
            Thread.Sleep(1000);
            Console.WriteLine("Вы едите к точке Б.");
            Thread.Sleep(1000);
            Point_B_Berlin_Tank_Battle(tank);
        }
        static void EventBerlin3(Tank tank)
        {
            Console.WriteLine("Игра началась! Задача захватить точку C");
            Start_Tank(tank);
            Thread.Sleep(1000);
            Console.WriteLine("Вы едите к точке C.");
            Thread.Sleep(1000);
            Point_C_Berlin_Tank_Battle(tank);
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

            public void Shot_on_Tank(Tank a, int damage)
            {
                a.HP -= damage;
            }
            public void Turn_On_The_Engine(Tank a)
            {
                a.Engine_Сondition = true;
            }

            public void Turn_Off_The_Engine(Tank a)
            {
                a.Engine_Сondition = false;
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
            private string _name = "Pz.Kpfw. III";
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

    namespace Enemys
    {
        public abstract class Enemy 
        {
            public abstract string Name { get; set; }
            public abstract int HP { get; protected set; }
            public abstract int Damage { get; protected set; }

            public void Shot_on_Enemy(Enemy a, int damage)
            {
                a.HP -= damage;
            }
        }
        public class Platoon_Of_Stormtroopers : Enemy
        {
            private string _name = "Взвод штурмовиков";
            private int _hp = 20;
            private int _damage = 5;

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
        }
        public class Howitzer : Enemy
        {
            private string _name = "Гаубица";
            private int _hp = 15;
            private int _damage = 30;

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
        }
        public class Platoon_Of_Grenadiers : Enemy
        {
            private string _name = "Взвод гренадеров";
            private int _hp = 25;
            private int _damage = 10;

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
        }
    }
}