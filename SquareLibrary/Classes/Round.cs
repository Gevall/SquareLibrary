using SquareLibrary.Interfaces;

namespace SquareLibrary.Classes
{
    public class Round : IGetSquare
    {
        public double GetSquare(string input)
        {
            Console.Write("Введите радиус круга: ");
            var radius = double.Parse(input);
            if (radius > 0)
            {
                var square = Math.Pow(Math.PI * radius, 2);
                return Math.Round(square, 2);
            }
            // Данные заданы неверно. Возвращаем 0
            return 0;
        }
    }
}
