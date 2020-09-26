//Арсаланов ПрИ-101
using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            //инициализация переменных и приветствие
            string step0, step1;
            int FigureType;

            Console.WriteLine("Привет!");

            //выбор фигуры
            Console.WriteLine("Выберите фигуру:");
            Console.WriteLine("1)Пешка\n2)Конь\n3)Ладья\n4)Слон\n5)Ферзь\n6)Король");
            //проверка правильности ввода фигуры
            FigureType = GetFigureType();

            //Ввод ходов
            step0 = GetChessMove();
            step1 = GetChessMove();

            //проверка
            IsStepRight(step0, step1, FigureType);
        }
        //получение хода
        static string GetChessMove()
        {
            string step;
            do
            {
                Console.WriteLine("Введите координаты коня до хода:");
                step = Console.ReadLine();
                StrOptimization(ref step);
            } while (IsInputWrong(step));
            return step;
        }

        //выбор фигуры
        static int GetFigureType()
        {
            string key_str;
            int key;
            bool result;
            do    //проверка правильности ввода фигуры
            {
                key_str = Console.ReadLine();
                result = int.TryParse(key_str, out key);
            } while (IsInputWrong(key, result));
            return key;
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
        static bool IsInputWrong(int key,bool result)   //перегрузка
        {
            if (!result || key < 1 || key > 6)
            {
                Console.WriteLine("Введено некорректное значение!");
                return true;
            }
            else return false;
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
        static void IsStepRight(string s0, string s1, int key)   //bool or void?
        {
            //получаем координаты
            int[] s0_xy = GetCoordinates(s0);
            int[] s1_xy = GetCoordinates(s1);
            bool res=false;
            switch(key)
            {
                case 1:
                    res = IsPawnCorrect(s0_xy, s1_xy);
                    break;
                case 2:
                    res = IsKnightCorrect(s0_xy, s1_xy);
                    break;
                case 3:
                    res = IsRookCorrect(s0_xy, s1_xy);
                    break;
                case 4:
                    res = IsBishopCorrect(s0_xy, s1_xy);
                    break;
                case 5:
                    res = IsQueenCorrect(s0_xy, s1_xy);
                    break;
                case 6:
                    res = IsKingCorrect(s0_xy, s1_xy);
                    break;
            }

            if (res) Console.WriteLine("Ход корректен!");
            else Console.WriteLine("Ход некорректен!");
        }

        //проверка правильности хода пешкой(Pawn)
        static bool IsPawnCorrect(int[] s0_xy,int[] s1_xy)
        {
            if (s0_xy[0] == s1_xy[0] && ((s0_xy[1] == 1 && (s0_xy[1] - 1 == s1_xy[1] ||
                                                            s0_xy[1] + 1 == s1_xy[1] ||
                                                            s0_xy[1] + 2 == s1_xy[1])) ||

                                        ((s0_xy[1] == 6 && (s0_xy[1] - 2 == s1_xy[1] ||
                                                            s0_xy[1] - 1 == s1_xy[1] ||
                                                            s0_xy[1] + 1 == s1_xy[1])) ||

                                        ((s0_xy[1] > 1 && s0_xy[1] < 6) && (s0_xy[1] - 1 == s1_xy[1] ||
                                                                            s0_xy[1] + 1 == s1_xy[1]))))) return true;
            else return false;
        }
        //проверка правильности хода королём(King)
        static bool IsKingCorrect(int[] s0_xy, int[] s1_xy)
        {
            if (((s0_xy[0] - 1 == s1_xy[0] || s0_xy[0] + 1 == s1_xy[0]) && (s0_xy[1] - 1 == s1_xy[1] || 
                                                                            s0_xy[1] == s1_xy[1] ||
                                                                            s0_xy[1] + 1 == s1_xy[1])) ||

                ((s0_xy[0] == s1_xy[0]) && ((s0_xy[1] - 1 == s1_xy[1]) ||
                                            (s0_xy[1] + 1 == s1_xy[1])))) return true;
            else return false;
        }
        //проверка правильности хода конём(Knight)
        static bool IsKnightCorrect(int[] s0_xy, int[] s1_xy)
        {
            if ((s0_xy[0] - 2 == s1_xy[0] && (s0_xy[1] - 1 == s1_xy[1] ||
                                              s0_xy[1] + 1 == s1_xy[1])) ||

                (s0_xy[0] - 1 == s1_xy[0] && (s0_xy[1] - 2 == s1_xy[1] ||
                                              s0_xy[1] + 2 == s1_xy[1])) ||

                (s0_xy[0] + 1 == s1_xy[0] && (s0_xy[1] - 2 == s1_xy[1] ||
                                              s0_xy[1] + 2 == s1_xy[1])) ||

                (s0_xy[0] + 2 == s1_xy[0] && (s0_xy[1] - 1 == s1_xy[1] ||
                                              s0_xy[1] + 1 == s1_xy[1]))) return true;
            else return false;
        }
        //проверка правильности хода ладьёй(Rook)
        static bool IsRookCorrect(int[] s0_xy, int[] s1_xy)
        {
            if (s0_xy[0] == s1_xy[0] || s0_xy[1] == s1_xy[1]) return true;
            else return false;
        }
        //проверка правильности хода слоном(Bishop)
        static bool IsBishopCorrect(int[] s0_xy, int[] s1_xy)
        {
            for(int i=1;i<8;i++)
            {
                if ((s0_xy[0] - i == s1_xy[0] || s0_xy[0] + i == s1_xy[0]) && (s0_xy[1] - i == s1_xy[1] ||
                                                                               s0_xy[1] + i == s1_xy[1])) return true;
            }
            return false;
        }
        //проверка правильности хода ферзём(Queen)
        static bool IsQueenCorrect(int[] s0_xy, int[] s1_xy)
        {
            if (IsRookCorrect(s0_xy, s1_xy) || IsBishopCorrect(s0_xy, s1_xy)) return true;
            else return false;
        }

    }
}
