using System;

namespace FlyweightPattern;

public class Point
{
    private int x;
    private int y;
    private PointType type;
    private byte[] icon;

    public Point(int x, int y, PointType type, byte[] icon)
    {
        this.x = x;
        this.y = y;
        this.type = type;
        this.icon = icon;
    }

    public void Draw()
    {
        Console.WriteLine($"{type} at ({x}, {y}) length: {icon.Length} b");
    }
}

public enum PointType
{
    Cafe,
    Bank,
    Hotel
}