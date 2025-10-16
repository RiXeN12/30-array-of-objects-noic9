using System;
using System.Linq;

namespace LabWork
{
    // Даний проект є шаблоном для виконання лабораторних робіт
    // з курсу "Об'єктно-орієнтоване програмування та патерни проектування"
    // Необхідно змінювати і дописувати код лише в цьому проекті
    // Відео-інструкції щодо роботи з github можна переглянути 
    // за посиланням https://www.youtube.com/@ViktorZhukovskyy/videos 

    class Circle
    {
        // Поля класу
        private double radius;      // Радіус круга
        private double centerX;     // X-координата центру
        private double centerY;     // Y-координата центру

        // Конструктор
        public Circle(double radius, double centerX, double centerY)
        {
            this.radius = radius;
            this.centerX = centerX;
            this.centerY = centerY;
        }

        // Властивості
        public double Radius
        {
            get { return radius; }
            set { radius = value > 0 ? value : 0; }
        }

        public double CenterX
        {
            get { return centerX; }
            set { centerX = value; }
        }

        public double CenterY
        {
            get { return centerY; }
            set { centerY = value; }
        }

        // Метод для обчислення площі круга
        public double GetArea()
        {
            return Math.PI * radius * radius;
        }

        // Метод для виведення інформації про круг
        public void DisplayInfo()
        {
            Console.WriteLine($"Круг: центр ({centerX:F2}, {centerY:F2}), радіус = {radius:F2}, площа = {GetArea():F2}");
        }

        // Перевизначення методу ToString
        public override string ToString()
        {
            return $"Круг: центр ({centerX:F2}, {centerY:F2}), радіус = {radius:F2}, площа = {GetArea():F2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Введення кількості кругів
            Console.Write("Введіть кількість кругів (n): ");
            int n = int.Parse(Console.ReadLine());

            // Створення масиву кругів
            Circle[] circles = new Circle[n];

            // Заповнення масиву
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nКруг №{i + 1}:");

                Console.Write("Введіть радіус: ");
                double radius = double.Parse(Console.ReadLine());

                Console.Write("Введіть X-координату центру: ");
                double x = double.Parse(Console.ReadLine());

                Console.Write("Введіть Y-координату центру: ");
                double y = double.Parse(Console.ReadLine());

                circles[i] = new Circle(radius, x, y);
            }

            // Виведення всіх кругів
            Console.WriteLine("\n=== Всі круги ===");
            for (int i = 0; i < circles.Length; i++)
            {
                Console.Write($"{i + 1}. ");
                circles[i].DisplayInfo();
            }

            // Пошук круга з найбільшою площею
            Circle maxCircle = circles[0];
            int maxIndex = 0;

            for (int i = 1; i < circles.Length; i++)
            {
                if (circles[i].GetArea() > maxCircle.GetArea())
                {
                    maxCircle = circles[i];
                    maxIndex = i;
                }
            }

            // Виведення результату
            Console.WriteLine("\n=== Круг з найбільшою площею ===");
            Console.WriteLine($"Індекс: {maxIndex + 1}");
            maxCircle.DisplayInfo();

            Console.ReadKey();
        }
    }
}