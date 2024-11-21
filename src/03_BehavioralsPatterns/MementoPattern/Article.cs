namespace MementoPattern;

public class Article
{
    public string Content { get; set; }
    public string Title { get; set; }

    // Backup
    public ArticleMemento CreateMemento() => new ArticleMemento(this.Content, this.Title);

    // Restore
    public void SetMemento(ArticleMemento memento)
    {
        this.Content = memento.Content;
        this.Title = memento.Title;
    }
}
