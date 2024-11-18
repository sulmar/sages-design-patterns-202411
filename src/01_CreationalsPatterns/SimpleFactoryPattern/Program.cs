using System;
using System.Net.Http.Headers;

namespace SimpleFactoryPattern
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Factory Method Pattern!");

            VisitCalculateAmountTest();
        }

       

        private static void VisitCalculateAmountTest()
        {
            VisitFactory2 visitFactory = new VisitFactory2();

            visitFactory.Register("N", new NfzCalculateCostStrategy());
            visitFactory.Register("P", new PrivateCalculateCostStrategy(new VisitOptions(100)));
            visitFactory.Register("F", new CompanyCalculateCostStrategy(new CompanyVisitOptions(100, 0.9m)));
            

            while (true)
            {
                Console.Write("Podaj rodzaj wizyty: (N)FZ (P)rywatna (F)irma: ");
                string visitType = Console.ReadLine();

                Console.Write("Podaj czas wizyty w minutach: ");
                if (double.TryParse(Console.ReadLine(), out double minutes))
                {
                    TimeSpan duration = TimeSpan.FromMinutes(minutes);

                    ICalculateCostStrategy calculateCostStrategy = visitFactory.Create(visitType);
                    
                    Visit visit = new Visit();
                    visit.SetStrategy(calculateCostStrategy);

                    decimal totalAmount = visit.CalculateCost(duration);

                    if (totalAmount == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                       if (totalAmount >= 200)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine($"Total amount {totalAmount:C2}");

                    Console.ResetColor();
                }
            }

        }
    }
}
