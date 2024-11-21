using System.Text;
using System.Threading;

namespace VisitorPattern;

// Abstract Element
public abstract class Control
{
    public string Name { get; set; }
    public string Caption { get; set; }

    public abstract void Accept(IVisitor visitor);
}

public class Label : Control
{
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class TextBox : Control
{
    public string Value { get; set; }

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Checkbox : Control
{
    public bool Value { get; set; }

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Button : Control
{
    public string ImageSource { get; set; }

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}


// Abstract Visitor
public interface IVisitor
{
    void Visit(Form form);
    void Visit(Label label);
    void Visit(TextBox textBox);
    void Visit(Checkbox checkbox);
    void Visit(Button button);

    string GetHtml();
}


// Concrete Visitor A
public class HtmlVisitor : IVisitor
{
    private StringBuilder builder = new StringBuilder();

    public HtmlVisitor()
    {
        AddHeader();
    }

    private void AddHeader()
    {
        builder.AppendLine("<html>");
    }

    private void AddFooter()
    {
        builder.AppendLine("</body>");
        builder.AppendLine("</html>");
    }

    public void Visit(Label control)
    {
        builder.AppendLine($"<span>{control.Caption}</span>");
    }

    public void Visit(TextBox control)
    {
        builder.AppendLine($"<span>{control.Caption}</span><input type='text' value='{control.Value}'></input>");
    }

    public void Visit(Checkbox control)
    {
        builder.AppendLine($"<span>{control.Caption}</span><input type='checkbox' value='{control.Value}'></input>");
    }

    public void Visit(Button control)
    {
        builder.AppendLine($"<button><img src='{control.ImageSource}'/>{control.Caption}</button>");
    }

    public void Visit(Form form)
    {
        foreach (var child in form.Body)
        {
            child.Accept(this);
        }
    }

    public string GetHtml()
    {
        AddFooter();

        return builder.ToString();

    }
}


