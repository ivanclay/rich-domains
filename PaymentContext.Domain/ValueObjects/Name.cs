using Flunt.Validations;
using PaymentContext.Shared.ValueObject;

namespace PaymentContext.Domain.ValueObjects;

    public class Name: ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<string>()
            .Requires()
            .IsLowerThan(FirstName.Length, 3, "Name.FirstName", "The first name must be longer than 3 characters.")
            .IsGreaterThan(FirstName.Length, 10, "Name.FirstName", "The first name must be less than 10 characters.")
            .IsNullOrEmpty(FirstName, "Name.FirstName","Invalid first name"));

            AddNotifications(new Contract<string>()
            .Requires()
            .IsLowerThan(LastName.Length, 3, "Name.LastName", "The last name must be longer than 3 characters.")
            .IsGreaterThan(LastName.Length, 10, "Name.LastName", "The last name must be less than 10 characters.")
            .IsNullOrEmpty(LastName, "Name.LastName","Invalid last name"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }