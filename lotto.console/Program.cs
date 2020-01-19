using lotto.core;
using System;

namespace lotto.console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var draws = Lotto.GetDraws();

            foreach (var draw in draws)
            {
                PlotDraw(draw);
                Console.WriteLine();
            }
        }

        private static void PlotDraw(Draw draw)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(draw.Name);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{draw.CurrentDate.ToString("dd.MM.yyyy")}: ");
            Console.ResetColor();

            foreach (var number in draw.Numbers)
            {
                Console.Write(number + " ");
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (var number in draw.SpecialNumbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"Next draw: ");
            Console.ResetColor();
            Console.WriteLine(draw.NextDate.ToString("dd.MM.yyyy HH:mm"));
        }
    }
}
