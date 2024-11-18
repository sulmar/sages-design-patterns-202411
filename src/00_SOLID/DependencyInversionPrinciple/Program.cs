// Zasada odwracania zależności (Dependency Inversion Principle) – DIP
// Wszystkie zależności powinny w jak największym stopniu zależeć od abstrakcji a nie od konkretnego typu.
// Oznacza to, że w kodzie powinny być używane interfejsy lub klasy abstrakcyjne, zamiast bezpośrednio operować na konkretnych klasach.
    
// Przykład łamiący zasadę odwracania zależności

var controller = new ProductController(new DbProductRepository());
var product = controller.Get(1);

public class ProductController
{
    private DbProductRepository repository;

    public ProductController(DbProductRepository repository)
    {
        this.repository = repository;
    } 
    
    public Product Get(int id)
    {
        return repository.GetById(id);
    }

    public void Post(Product product) 
    { 
        repository.Add(product);
    }
}

public class DbProductRepository
{
    public Product GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Add(Product product)
    {

    }
}

public class CloudProductRepository
{
    public Product Load(int id)
    {
        throw new NotImplementedException();
    }

    public void Save(Product product)
    {

    }
}

public class Product
{

}