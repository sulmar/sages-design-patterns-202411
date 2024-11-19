using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern;

internal class CustomerDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
}

class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address HomeAddress { get; set; }
}

class Address
{
    public string Street { get; set; }
    public string City { get; set; }
}
    
