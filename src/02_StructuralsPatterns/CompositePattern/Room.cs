using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern;

public class Building
{
    public string Name { get; set; }
    public Roof Roof { get; set; }
    public List<Room> Rooms { get; set; }
    public Floor Floor { get; set; }
}

public class Room
{
    public string Name { get; set; }
    public List<Furniture> Furnitures { get; set; }
}

public class Floor
{
    public string Name { get; set; }
}


public class Roof
{
    public string Name { get; set; }
}

public class Furniture
{
    public string Name { get; set; }
}