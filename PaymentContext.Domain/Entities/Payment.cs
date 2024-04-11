
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;
public abstract class Payment: Entity
{
    protected Payment(
        DateTime date,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        Address address,
        string payer,
        Document document,
        Email email)
    {
        Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,10).ToUpper();
        Date = date;
        ExpireDate = expireDate;
        Total = total;
        TotalPaid = totalPaid;
        Address = address;
        Payer = payer;
        Document = document;
        Email = email;

        AddNotifications(
            new Contract<Payment>()
            .Requires()
            .IsGreaterThan(0, Total, "Payment.Total", "Total cannot be zero.")
            .IsGreaterOrEqualsThan(Total, totalPaid, "Payment.TotalPaid", "Total paid must be minor."));

        //TODO validations            
    }


    public string Number { get; private set; }
    public DateTime Date { get; private set; }
    public DateTime PaidDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public Address Address { get; private set; }
    public string Payer { get; private set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
}