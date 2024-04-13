using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Commands;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers;

[TestClass]
public class SubscriptionHandlerTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenDocumentExists(){
        var handler = new SubscriptionHandler(new FakeStudentRpository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand();
        command.BarCode = "00000000";
        command.BoletoNumber = "00000000";
        command.FirstName = "QWERTY";
        command.LastName = "QWERTY";
        command.Document = "999999999";
        command.Email = "hello@clayplayground.com";
        command.City = "NYC";
        command.Country = "USA";
        command.ExpireDate = DateTime.Now;
        command.Neighborhood = "NYC";
        command.Number = "111";
        command.PaidDate = DateTime.Now;
        command.Payer = "QWERTY";
        command.PayerDocument = "12345678912";
        command.PayerDocumentType = EDocumentType.CPF;
        command.PayerEmail = "hello@clayplayground.com";
        command.PaymentNumber = "1111111";
        command.State = "NYC";
        command.Street = "8th";
        command.Total = 60;
        command.TotalPaid = 60;
        command.ZipCode = "123456";

        handler.Handle(command);
        Assert.AreEqual(false, handler.IsValid);
    }
}