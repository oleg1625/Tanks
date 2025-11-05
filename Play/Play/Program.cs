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
            Console.Write("Здраствуйте, дорогой игрок. \nТанки на выбор: \n 1. Panther D \n 2. T34-85 \n 3. M4 Sherman \nВыберите технику: ");

            bool trigger = true;

            while (trigger)
            {
                int tank_selection = Convert.ToInt32(Console.ReadLine());
                switch (tank_selection)
                {
                    case 1:
                        Console.WriteLine("Вы выбрали Panther D");
                        trigger = false;
                        break;
                    case 2:
                        Console.WriteLine("Вы выбрали T34-85");
                        trigger = false;
                        break;
                    case 3:
                        Console.WriteLine("Вы выбрали M4 Sherman");
                        trigger = false;
                        break;
                    default:
                        Console.Write("Некорректный ввод. Выберите ещё раз: ");
                        break;

                }
            }

            Console.ReadKey();

        }
    }

    namespace Tanks
    {
        public abstract class Tank
        {
            public abstract int HP { get; protected set; }
            public abstract int Damage { get; protected set; }

            public void Shot(Tank a, int damage) 
            {
                a.HP -= damage;
            }

        }
    

        public class T34_85 : Tank
        {
            private int _hp = 100;
            private int _damage = 15;
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
            private int _hp = 120;
            private int _damage = 25;
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
            private int _hp = 140;
            private int _damage = 10;
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
        public static void Registration() 
        {
        
        }
    }
    
}
