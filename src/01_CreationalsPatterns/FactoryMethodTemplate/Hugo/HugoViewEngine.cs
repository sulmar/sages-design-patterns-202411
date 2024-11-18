using FactoryMethodTemplate.Abstractions;
using FactoryMethodTemplate.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodTemplate.Hugo;

public class HugoViewEngine : IViewEngine
{
    public string Render(string viewName, IDictionary<string, object> context)
    {
        return "View rendered by Hugo";
    }
}


public class HugoController : Controller
{
    protected override IViewEngine CreateViewEngine()
    {
        return new HugoViewEngine();
    }
}