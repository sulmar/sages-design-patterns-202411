namespace CompositePattern;

public class CompositeCustomerValidator : ICustomerValidator
{
    private IEnumerable<ICustomerValidator> validators;

    public CompositeCustomerValidator(IEnumerable<ICustomerValidator> validators)
    {
        this.validators = validators;
    }

    public bool Validate(Customer customer)
    {
        return validators.All(validator => validator.Validate(customer));        
    }
}
