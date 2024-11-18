// Zasada podstawiania Liskov (Liskov Substitution Principle) - LSP  
// Zasada Liskov mówi o tym, że obiekt klasy pochodnej może być używany zamiennie
// w miejscu obiektu klasy bazowej, nie wprowadzając nieoczekiwanych zachowań.

// Przykład łamiący zasadę podstawiania Liskov

Document doc1 = new PDFDocument();
Document doc2 = new TextDocument();

doc1.Print();  // Output: "Printing a PDF document..."
((TextDocument)doc2).Edit();  // This is Breaking the Liskov Substitution Principle

class Document
{
    public virtual void Print()
    {
        Console.WriteLine("Printing a document...");
    }
}

class PDFDocument : Document
{
    public override void Print()
    {
        Console.WriteLine("Printing a PDF document...");
    }

    public void Encrypt()
    {
        Console.WriteLine("Encrypting a PDF document...");
    }    
}

class TextDocument : Document
{
    public override void Print()
    {
        Console.WriteLine("Printing a text document...");
    }

    public void Edit()
    {
        Console.WriteLine("Editing a document...");
    }


}