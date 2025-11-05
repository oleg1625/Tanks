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
                        Console.Write("Нкорректный ввод. Выберите ещё раз: ");
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

        }
        }

        public class T34 : Tank
        {
            public
        }
    }
}
