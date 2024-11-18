using FactoryMethodTemplate.Abstractions;
using System.Collections.Generic;

namespace FactoryMethodTemplate.Razor
{
    public class Controller
    {
        public string Render(string viewName, IDictionary<string, object> context)
        {
            IViewEngine engine = CreateViewEngine();
            var html = engine.Render(viewName, context);

            return html;
        }

        protected virtual IViewEngine CreateViewEngine()
        {
            return new RazorViewEngine();
        }
    }
}
