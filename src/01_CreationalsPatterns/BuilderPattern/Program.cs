using BuilderPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static BuilderPattern.SalesReportBuilder;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Builder Pattern!");

            // PresentationTest();


            //PhoneTest();

            // SalesReportTest();

            // PersonTest();

            RoomTest();
        }

        private static void PresentationTest()
        {
            MoviePresentationBuilder presentationBuilder = new MoviePresentationBuilder();

            Presentation presentation = new Presentation(presentationBuilder);
            presentation.AddSlide(new Slide("a"));
            presentation.AddSlide(new Slide("b"));
            presentation.AddSlide(new Slide("c"));

            presentation.Export();

            var document = presentationBuilder.GetMovie();
        }

        private static void RoomTest()
        {
            // Opcje konfiguracji pokoju
            var roomWidth = 500;
            var roomHeight = 300;

            // Tworzenie sufitu
            var ceiling = new Ceiling(roomWidth, roomHeight);


            RoomBuilder builder = new RoomBuilder();
            builder
                .ConfigureRoom(options =>
                    {
                        options.Width = roomWidth;
                        options.Height = roomHeight;
                    })
                .AddWalls(walls =>
                    {
                        walls.Color = "Red";
                        walls.Width = 200;
                        walls.Height = 250;
                        walls.Position = WallPosition.North | WallPosition.South;
                    });

            // Tworzenie pokoju
            var room = builder.Build();


            // Wyświetlenie pokoju

            Console.WriteLine(room);
        }

        private static void PersonTest()
        {
            var person = new Person();

            person.Name = "Marcin";
            person.Position = "developer";
            person.AddSkill("C#");
            person.AddSkill("design-patterns");
            person.AddSkill("tdd");

            Console.WriteLine(person);
        }

        private static void SalesReportTest()
        {
            FakeOrdersService ordersService = new FakeOrdersService();
            IEnumerable<Order> orders = ordersService.Get();

            bool hasFooter = true;

            SalesReportBuilder builder = new SalesReportBuilder();
            builder
                .WithOrders(orders)
                .AddHeader("Raport sprzedaży")
                .AddContent();          // Łańcuch metod (FluentApi)

            if (hasFooter)
                builder.AddFooter();

            SalesReport salesReport = builder.Build();

            Console.WriteLine(salesReport);

        }

        private static void PhoneTest()
        {
            Phone phone = new Phone();
            phone.Call("555999123", "555000321", ".NET Design Patterns");
        }


    }

    public class FakeOrdersService
    {
        private readonly IList<Product> products;
        private readonly IList<Customer> customers;

        public FakeOrdersService()
            : this(CreateProducts(), CreateCustomers())
        {

        }

        public FakeOrdersService(IList<Product> products, IList<Customer> customers)
        {
            this.products = products;
            this.customers = customers;
        }

        private static IList<Customer> CreateCustomers()
        {
            return new List<Customer>
            {
                 new Customer("Anna", "Kowalska"),
                 new Customer("Jan", "Nowak"),
                 new Customer("John", "Smith"),
            };

        }

        private static IList<Product> CreateProducts()
        {
            return new List<Product>
            {
                new Product(1, "Książka C#", unitPrice: 100m),
                new Product(2, "Książka Praktyczne Wzorce projektowe w C#", unitPrice: 150m),
                new Product(3, "Zakładka do książki", unitPrice: 10m),
            };
        }

        public IEnumerable<Order> Get()
        {
            Order order1 = new Order(DateTime.Parse("2020-06-12 14:59"), customers[0]);
            order1.AddDetail(products[0], 2);
            order1.AddDetail(products[1], 2);
            order1.AddDetail(products[2], 3);

            yield return order1;

            Order order2 = new Order(DateTime.Parse("2020-06-12 14:59"), customers[1]);
            order2.AddDetail(products[0], 2);
            order2.AddDetail(products[1], 4);

            yield return order2;

            Order order3 = new Order(DateTime.Parse("2020-06-12 14:59"), customers[2]);
            order2.AddDetail(products[0], 2);
            order2.AddDetail(products[2], 5);

            yield return order3;


        }
    }




}