using System.Collections.Generic;

namespace MementoPattern;

// Concrete Caretaker A
public class StackArticleCaretaker : IArticleCaretaker
{
    private Stack<ArticleMemento> _mementos = new Stack<ArticleMemento>();
    public ArticleMemento GetState() => _mementos.Pop();
    public void SetState(ArticleMemento memento) => _mementos.Push(memento);
}
