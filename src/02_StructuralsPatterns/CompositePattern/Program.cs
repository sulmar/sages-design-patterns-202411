
namespace CompositePattern;

class Program
{
    static void Main(string[] args)
    {
        IEnumerable<ICustomerValidator> validators = 
         [
            new TaxNumberValidator(),
            new RegonValidator()
        ];

        ICustomerValidator composeValidator = new CompositeCustomerValidator(validators);

        CustomerController customerController = new CustomerController(composeValidator);

        var customer = new Customer { TaxNumber = "123", Regon = "123" };

        try
        {
            customerController.Post(customer);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        LoggerTest();

        // BuildingTest();

       // FormTest();

        Console.ReadLine();

    }

    private static void LoggerTest()
    {

        CompositeLogger composite = new CompositeLogger();
        composite.AddLogger(new SqlLogger("server=abc"));
        composite.AddLogger(new WindowsEventLogLogger(source: "My app"));
        composite.AddLogger(new FileLogger(directory: "c:\\logs"));

        var component = new Component(composite);

        component.DoSomething();
    }

    private static void BuildingTest()
    {
        var floor = new Floor("First floor");

        var building = new Building("My House");
        building.Add(floor);

        var livingRoom = new Room("Living room");
        var bedRoom = new Room("Bed room");

        floor.Add(livingRoom);
        floor.Add(bedRoom);

        var table = new Furniture("Table");
        var table2 = new Furniture("Table 2");
        livingRoom.Add(table);
        livingRoom.Add(table2);



        building.Display();
    }

    private static void FormTest()
    {
        IQuestion questionDP = new Decision("Welcome on Design Pattern in C# Course!");
        IQuestion questionNotDP = new Decision("The Course is not for you.");        

        Question questionDeveloper = new Question("Are you developer?");
        Question questionCsharp = new Question("Do you know C#?");
        IQuestion questionNotDeveloper = new Decision("Have a nice day.");

        questionDeveloper.AddPositiveAction(questionCsharp);
        questionDeveloper.AddNegativeAction(questionNotDeveloper);

        questionCsharp.AddPositiveAction(questionDP);
        questionCsharp.AddNegativeAction(questionNotDP);
        
        questionDeveloper.Ask();

    }

}
