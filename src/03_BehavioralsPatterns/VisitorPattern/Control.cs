namespace VisitorPattern;

// Abstract Element
public abstract class Control
{
    public string Name { get; set; }
    public string Caption { get; set; }    
}

public class Label : Control
{

}

public class TextBox : Control
{
    public string Value { get; set; }
}

public class Checkbox : Control
{
    public bool Value { get; set; }
}

public class Button : Control
{
    public string ImageSource { get; set; }
}

