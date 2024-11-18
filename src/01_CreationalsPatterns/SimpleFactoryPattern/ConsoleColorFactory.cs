using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryPattern;

public class ConsoleColorFactory
{
    public ConsoleColor Create(decimal amount) => amount switch
    {
        0 => ConsoleColor.Green,
        >= 200 => ConsoleColor.Red,
        _ => ConsoleColor.White,
    };
}
