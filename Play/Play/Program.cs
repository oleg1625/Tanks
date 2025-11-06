using Play.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Play
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Инициализация переменных
            int tank_selection;
            int map_selection = 0;
            bool trigger1 = true;
            bool trigger2 = true;
            Tank TankPlayer = null;
            /*
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
            */
            Console.Write("Карты: \n 1.Берлин \n\n Выберите карту: ");

            while (trigger2)
            {
                map_selection = Convert.ToInt32(Console.ReadLine());

                switch (map_selection) 
                {
                    case 1:
                        trigger2 = false;
                        break;
                    default:
                        Console.Write("Некорректный ввод. Выберите ещё раз: ");
                        break;
                }
            }

            //if (map_selection )

           
            Console.ReadKey();

        }
    }

    namespace Tanks
    {
        public abstract class Tank
        {
            public abstract string Name { get; set;  }
            public abstract int HP { get; protected set; }
            public abstract int Damage { get; protected set; }

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

        }
        public class Panther_D : Tank
        {
            private string _name = "Panther D";
            private int _hp = 120;
            private int _damage = 25;

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

        }
        public class M4_Sherman : Tank
        {
            private string _name = "M4 Sherman";
            private int _hp = 140;
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

        }

    }

    namespace system_void 
    {
       
    }
    
}
