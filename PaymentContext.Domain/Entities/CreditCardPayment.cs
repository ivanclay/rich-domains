using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class CreditCardPayment: Payment
{
    public CreditCardPayment(string cardHolderName,
    string cardNumber, string lastTransctionNumber,
    DateTime date, DateTime expireDate, decimal total,
    decimal totalPaid, Address address,
    string payer, Document document, Email email):base(date, expireDate,
        total, totalPaid, address, payer, document, email)
    {
        CardHolderName = cardHolderName;
        CardNumber = cardNumber;
        LastTransctionNumber = lastTransctionNumber;
    }

    public string CardHolderName { get; private set; }
    public string CardNumber { get; private set; }
    public string LastTransctionNumber { get; private set; }
}
