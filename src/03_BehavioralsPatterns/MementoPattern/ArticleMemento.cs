using System;

namespace MementoPattern;

// Migawka (snapshot)
public class ArticleMemento 
{
    public string Content { get; }
    public string Title { get; }
    public DateTime SnapshotDate { get; }

    public ArticleMemento(string content, string title)
    {
        Content = content;
        Title = title;
        SnapshotDate = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{SnapshotDate} {Title} {Content}";
    }
}
