using System;
using System.Linq;

namespace LabWork
{
    // Даний проект є шаблоном для виконання лабораторних робіт
    // з курсу "Об'єктно-орієнтоване програмування та патерни проектування"
    // Необхідно змінювати і дописувати код лише в цьому проекті
    // Відео-інструкції щодо роботи з github можна переглянути 
    // за посиланням https://www.youtube.com/@ViktorZhukovskyy/videos 

    
    class Program
    {
        static void Main(string[] args)

        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int n;
            while (true)
            {
                Console.Write("Введіть кількість кіл n (ціле > 0): ");
                string s = Console.ReadLine();
                if (int.TryParse(s, out n) && n > 0) break;
                Console.WriteLine("Невірне значення. Введіть ціле число більше 0.");
            }

            Circle[] circles = new Circle[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nКоло #{i + 1}:");

                double x;
                while (true)
                {
                    Console.Write("  Введіть X координату центру (дробове число допускається): ");
                    if (double.TryParse(Console.ReadLine(), out x)) break;
                    Console.WriteLine("  Невірний формат. Спробуйте ще раз.");
                }

                double y;
                while (true)
                {
                    Console.Write("  Введіть Y координату центру (дробове число допускається): ");
                    if (double.TryParse(Console.ReadLine(), out y)) break;
                    Console.WriteLine("  Невірний формат. Спробуйте ще раз.");
                }

                double r;
                while (true)
                {
                    Console.Write("  Введіть радіус (дробове число, > 0): ");
                    if (double.TryParse(Console.ReadLine(), out r) && r > 0) break;
                    Console.WriteLine("  Невірний радіус. Радіус має бути числом більше 0.");
                }

                circles[i] = new Circle(x, y, r);
            }

            Circle maxCircle = circles.OrderByDescending(c => c.Area()).First();

            Console.WriteLine("\nКоло з найбільшою площею:");
            Console.WriteLine(maxCircle.ToString());

            Console.WriteLine("\nУсі введені кола:");
            for (int i = 0; i < circles.Length; i++)
                Console.WriteLine($"#{i + 1}: {circles[i]}");

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }

    class Circle
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }

        public Circle(double x, double y, double radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public override string ToString()
        {
            return $"Center=({X}, {Y}), Radius={Radius}, Area={Area():F4}";
        }
    }
}
