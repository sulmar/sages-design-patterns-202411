using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern;

// Abstract Component
public abstract class BuildingComponent
{
    public string Name { get; set; }

    protected BuildingComponent(string name)
    {
        Name = name;        
    }

    public List<BuildingComponent> Children { get; set; } = new List<BuildingComponent>();

    public void Add(BuildingComponent component)
    {
        Children.Add(component);
    }

    public virtual void Display()
    {
        Console.WriteLine($"{Name}");

        foreach (var child in Children)
        {
            child.Display();
        }
    }
}

// Concrete Component
public class Building : BuildingComponent
{
    public Building(string name) : base(name)
    {
    }

   
}

public class Room : BuildingComponent
{
    public Room(string name) : base(name)
    {
    }
}

public class Floor : BuildingComponent
{
    public Floor(string name) : base(name)
    {
    }
}


public class Roof : BuildingComponent
{
    public Roof(string name) : base(name)
    {
    }
}

// Leaf
public class Furniture : BuildingComponent
{
    public Furniture(string name) : base(name)
    {
    }

    public override void Display()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        base.Display();
        Console.ResetColor();        
    }
}