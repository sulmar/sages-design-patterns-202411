namespace CompositePattern;

public class Group
{
    private List<object> objects = new List<object>();

    public void Add(Object shape)
    {
        objects.Add(shape);
    }

    public void Render()
    {
        foreach (var obj in objects)
        {
            if (obj is Shape)
                ((Shape)obj).Render();
            else 
                ((Group)obj).Render();
        }
    }
}