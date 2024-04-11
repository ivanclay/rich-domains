using Flunt.Validations;
using PaymentContext.Shared.ValueObject;

namespace PaymentContext.Domain.ValueObjects;
public class Address : ValueObject
{
    public Address(
        string street,
        string number,
        string neighborhood,
        string city,
        string state,
        string country,
        string zipCode)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;

        AddNotifications(new Contract<string>()
            .Requires()
            .IsLowerThan(Street, 3, "Address.Street","The first name must be longer than 3 characters.")
            .IsNullOrEmpty(Street, "Address.Street","Invalid first name"));
        
        //TODO add all Validations
    }


    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
}