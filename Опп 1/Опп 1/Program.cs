using System;
using System.Collections.Generic;


namespace ооп1
{
    internal class Program
    {
        private List<Triangle> triangles = new List<Triangle>();

        static void Main(string[] args)
        {
            Program menu = new Program();
            menu.Start();
        }

        public void Start()
        {
            bool exit = true;
            while (exit)
            {
                Console.WriteLine("\n--- Меню ---");
                Console.WriteLine("1. Додати трикутник");
                Console.WriteLine("2. Видалити трикутник за індексом");
                Console.WriteLine("3. Переглянути всі трикутники");
                Console.WriteLine("4. Переглянути трикутник за індексом");
                Console.WriteLine("5. Сортувати трикутники за площею");
                Console.WriteLine("6. Пошук трикутника за кольором");
                Console.WriteLine("7. Розрахувати загальну площу всіх трикутників");
                Console.WriteLine("0. Вийти");
                Console.Write("Оберіть опцію: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        DodatyTrykutnyk();
                        break;
                    case "2":
                        VydalytyTrykutnyk();
                        break;
                    case "3":
                        PerehlianyVsiTrykutnyky();
                        break;
                    case "4":
                        PerehlianyTrykutnykZaIndeksom();
                        break;
                    case "5":
                        SortuvatyTrykutnykyZaPloshcheyu();
                        break;
                    case "6":
                        PosukTrykutnykZaKolorom();
                        break;
                    case "7":
                        RozrakhunokZahalnoiPloshchi();
                        break;
                    case "0":
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Невірна опція. Спробуйте ще раз.");
                        break;
                }
            }
        }

        private void DodatyTrykutnyk()
        {
            Console.Write("Введіть сторону A: ");
            double sideA = double.Parse(Console.ReadLine());
            Console.Write("Введіть сторону B: ");
            double sideB = double.Parse(Console.ReadLine());
            Console.Write("Введіть сторону C: ");
            double sideC = double.Parse(Console.ReadLine());
            Console.Write("Введіть колір трикутника: ");
            string color = Console.ReadLine();
            Console.Write("Введіть індекс видимості трикутника (true/false): ");
            bool isVisible = bool.Parse(Console.ReadLine());

            Triangle triangle = new Triangle(sideA, sideB, sideC, color, isVisible);
            triangles.Add(triangle);
            Console.WriteLine("Трикутник успішно додано.");
        }

        private void VydalytyTrykutnyk()
        {
            Console.Write("Введіть індекс трикутника для видалення: ");
            int index = int.Parse(Console.ReadLine()) - 1;
            if (index >= 0 && index < triangles.Count)
            {
                triangles.RemoveAt(index);
                Console.WriteLine("Трикутник успішно видалено.");
            }
            else
            {
                Console.WriteLine("Невірний індекс.");
            }
        }

        private void PerehlianyVsiTrykutnyky()
        {
            Console.WriteLine("\n--- Всі трикутники ---");
            for (int i = 0; i < triangles.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                triangles[i].FormatneVyvedennia();
            }
        }

        private void PerehlianyTrykutnykZaIndeksom()
        {
            Console.Write("Введіть індекс трикутника для перегляду: ");
            int index = int.Parse(Console.ReadLine()) - 1;
            if (index >= 0 && index < triangles.Count)
            {
                triangles[index].FormatneVyvedennia();
            }
            else
            {
                Console.WriteLine("Невірний індекс.");
            }
        }

        private void SortuvatyTrykutnykyZaPloshcheyu()
        {
            triangles.Sort((x, y) => x.CalculateArea().CompareTo(y.CalculateArea()));
            Console.WriteLine("Трикутники відсортовані за площею.");
        }

        private void PosukTrykutnykZaKolorom()
        {
            Console.Write("Введіть колір для пошуку: ");
            string colorSearch = Console.ReadLine().ToLower();

            bool found = false;
            Console.WriteLine("\n--- Результати пошуку ---");
            foreach (var triangle in triangles)
            {
                if (triangle.GetColor().ToLower().Contains(colorSearch))
                {
                    triangle.FormatneVyvedennia();
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Жодного трикутника не знайдено.");
            }
        }

        private void RozrakhunokZahalnoiPloshchi()
        {
            double totalArea = 0;
            foreach (var triangle in triangles)
            {
                totalArea += triangle.CalculateArea();
            }
            Console.WriteLine($"Загальна площа всіх трикутників: {totalArea}");
        }
    }
}
