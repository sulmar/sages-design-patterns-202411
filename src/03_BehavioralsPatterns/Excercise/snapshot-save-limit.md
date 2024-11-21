# Tworzenie migawek z ograniczeniem do 3 zapisów

## Opis
Twoim zadaniem jest zaprojektowanie systemu, który pozwala na tworzenie migawek stanu obiektu, ale ogranicza ich liczbę do trzech. 
Każda migawka zapisuje stan obiektu w danym momencie, a po osiągnięciu limitu 3 migawek, najstarsza migawka zostaje nadpisana, gdy dodamy nową.


## Zadanie
Zaprojektuj i zaimplementuj system, który umożliwia:

- 1. Tworzenie migawek stanu obiektu (maksymalnie 3).
- 2. Przechowywanie migawek i nadpisywanie najstarszej, gdy przekroczony zostanie limit 3.
- 3. Przywracanie stanu obiektu na podstawie zapisanych migawek.
- 4. Migawka powinna zapisywać stan artykułu:

```cs
public class Article
{
    public string Content { get; set; }
    public string Title { get; set; }

	public override string ToString()
    {
        return $"Title: {Title}\nContent: {Content}";
    }
}
```

## Wymagania
- **1. Tworzenie migawek artykułów:**
Klasa powinna umożliwiać tworzenie migawek artykułu (zapisów stanu obiektu) w dowolnym momencie. 

- **2. Ograniczenie do 3 migawek:**
System musi przechowywać maksymalnie 3 migawek. Po osiągnięciu tego limitu, przy dodaniu nowej migawki, najstarsza migawka zostaje usunięta i nadpisana przez nową.


- **3. Przywracanie stanu:**
Powinna być możliwość przywrócenia obiektu do stanu z jednej z zapisanych migawek.