namespace CompositePattern;

public class CustomerController
{
    private readonly ICustomerValidator validator;

    public CustomerController(ICustomerValidator validator)
    {
        this.validator = validator;
    }

    public void Post(Customer customer)
    {
        bool isValid = validator.Validate(customer);

        if (!isValid)
        {
            throw new Exception();
        }
    }
}
