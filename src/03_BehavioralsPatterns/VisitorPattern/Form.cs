using System.Collections.Generic;

namespace VisitorPattern
{
    public class Form : Control
    {
        public string Title { get; set; }

        public ICollection<Control> Body { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
       
    }

}
