using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks;

public class FakeStudentRpository : IStudentRepository
{
    public void CreateSubscription(Student student)
    {
        
    }

    public bool DocumentExists(string document)
    {
        if(document == "999999999")
            return true;
        return false;
    }

    public bool EmailExists(string email)
    {
        if(email == "hello@clayplayground.com")
            return true;
        return false;
    }
}