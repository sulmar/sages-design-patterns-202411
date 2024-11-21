namespace MementoPattern
{
    // Abstract Caretaker (nadzorca)
    public interface IArticleCaretaker
    {
        void SetState(ArticleMemento memento);
        ArticleMemento GetState();       
    }
}
