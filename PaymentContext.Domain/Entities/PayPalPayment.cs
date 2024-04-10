using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class PayPalPayment: Payment
{
    public PayPalPayment(string transctionCode,
    DateTime date, DateTime expireDate, decimal total,
    decimal totalPaid, Address address,
    string payer, Document document, Email email):base(date, expireDate,
        total, totalPaid, address, payer, document, email)
    {
        TransctionCode = transctionCode;
    }

    public string TransctionCode { get; private set; }
}