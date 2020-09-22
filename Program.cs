//Арсаланов ПрИ-101
using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string step0, step1;
            Console.WriteLine("Привет!");

            //Ввод данных
            do
            {
                Console.WriteLine("Введите координаты коня до хода:");
                step0 = Console.ReadLine();
                StrOptimization(ref step0);
            } while (IsInputWrong(step0));
            do
            {
                Console.WriteLine("Введите координаты коня после хода:");
                step1 = Console.ReadLine();
                StrOptimization(ref step1);
            } while (IsInputWrong(step1));



            
        }

        //оптимизация строки
        static void StrOptimization(ref string step)
        {
            //удаление начальных и конечных пробелов
            step = step.Trim();
            //перевод символов в верхний регистр
            step = step.ToUpper();
        }

        //проверка правильности ввода
        static bool IsInputWrong(string step)
        {
            string Str = "ABCDEFGH";
            string Num = "87654321";

            //проверка на кол-во введенных символов
            if (step.Length != 2) return true;
            else
            {
                //проверка правильности введённых символов
                if (Str.Contains(step[0]) && Num.Contains(step[1])) return false;
                else return true;
            }
        }

        //получение координат
        static int[] GetCoordinates(string step)
        {
            int[] XY = new int[2];
            string Str = "ABCDEFGH";
            string Num = "87654321";

            for (int i = 0; i < 8; i++)
            {
                if (step[0] == Str[i]) XY[0] = i;
                if (step[1] == Num[i]) XY[1] = i;
            }
            return XY;
        }

        //проверка правильности хода
        static bool IsStepRight(string s0, string s1)   //bool or void?
        {
            //получаем координаты
            int[] s0_xy = GetCoordinates(s0);
            int[] s1_xy = GetCoordinates(s1);

            //проверка правильности хода конём
            if (((s0_xy[0] - 2 == s1_xy[0]) && ((s0_xy[1] - 1 == s1_xy[1])
                                             || (s0_xy[1] + 1 == s1_xy[1]))) ||
                ((s0_xy[0] - 1 == s1_xy[0]) && ((s0_xy[1] - 2 == s1_xy[1])
                                             || (s0_xy[1] + 2 == s1_xy[1]))) ||
                ((s0_xy[0] + 1 == s1_xy[0]) && ((s0_xy[1] - 2 == s1_xy[1])
                                             || (s0_xy[1] + 2 == s1_xy[1]))) ||
                ((s0_xy[0] + 2 == s1_xy[0]) && ((s0_xy[1] - 1 == s1_xy[1])
                                             || (s0_xy[1] + 1 == s1_xy[1])))) return true;
            else return false;

        }

    }
}
