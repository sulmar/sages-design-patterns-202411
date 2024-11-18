using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodTemplate.Abstractions;

public interface IViewEngine
{
    string Render(string viewName, IDictionary<string, object> context);
}
