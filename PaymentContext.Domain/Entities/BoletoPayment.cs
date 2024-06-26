using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class BoletoPayment: Payment
{
    public BoletoPayment(string barCode, string boletoNumber,
    DateTime date, DateTime expireDate, decimal total,
    decimal totalPaid, Address address,
    string payer, Document document, Email email):base(date, expireDate,
        total, totalPaid, address, payer, document, email)
    {
        BarCode = barCode;
        BoletoNumber = boletoNumber;
    }

    public string BarCode { get; private set; }
    public string BoletoNumber { get; private set; }
}
