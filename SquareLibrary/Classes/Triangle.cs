using SquareLibrary.Interfaces;
using System.Diagnostics;

namespace SquareLibrary.Classes
{
    public class Triangle : IGetSquare
    {
        /// <summary>
        /// Вычсиление площади треугольника
        /// </summary>
        public double GetSquare(string input)
        {
            //получение денных о сторонах треугольника
            string[] inputStr = input.Split(" ");
            //Проверка что заданы 3 стороны
            if (inputStr.Length == 3)
            {
                //Преобразование данных в число
                List<double> list = new List<double>();
                foreach (string line in inputStr)
                {
                    list.Add(double.Parse(line));
                }

                // Проверка является ли треугольник прямоугольным
                if (RectangularTriangle(list)) Debug.WriteLine("Треугольник прямоугольный");

                //Вычисление полупериметра для формулы Герона
                double semiperimeter = 0;
                foreach (double i in list)
                {
                    semiperimeter += i;
                }
                semiperimeter = semiperimeter / 2;

                //Вычисление площади треугольника и округление значений до 2 знаков после запятой
                var perimetr = Math.Round(Math.Sqrt(semiperimeter * (semiperimeter - list[0]) * (semiperimeter - list[1]) * (semiperimeter - list[2])), 2);

                if (perimetr > 0)
                {
                    return perimetr;
                }
                // Такого треугольника не существует. Возвращаем 0
                return 0;


            }
            // Данные заданы неверно. Возвращаем 0
            return 0;

        }

        /// <summary>
        /// Проверка является ли треугольник прямоугольным
        /// </summary>
        /// <param name="triangle">Стороны треугольника</param>
        /// <return>true - если треуольник прямоугольный, иначе - false</returns>
        private bool RectangularTriangle(List<double> triangle)
        {
            triangle.Sort();
            if (Math.Pow(triangle[2], 2) == Math.Pow(triangle[0], 2) + Math.Pow(triangle[1], 2)) return true;
            return false;
        }
    }
}
