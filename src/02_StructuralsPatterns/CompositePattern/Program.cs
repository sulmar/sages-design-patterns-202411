namespace CompositePattern;

class Program
{
    static void Main(string[] args)
    {
        // BuildingTest();

        FormTest();

        Console.ReadLine();

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
        IQuestion questionNotDeveloper = new Decision("Have a nice day.");

        IQuestion questionDP = new Decision("Welcome on Design Pattern in C# Course!");
        IQuestion questionNotDP = new Decision("The Course is not for you.");

        IQuestion questionCsharp = new Question("Do you know C#?", questionDP, questionNotDP);
        IQuestion questionDeveloper = new Question("Are you developer?", questionCsharp, questionNotDeveloper);

        questionDeveloper.Ask();

    }

}
