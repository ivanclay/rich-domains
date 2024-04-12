using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

[TestClass]
public class DocumentTests
{
    //RED, GREEN, REFACTOR
    
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        var doc = new Document("12345", EDocumentType.CNPJ);
        Assert.IsFalse(doc.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCNPJIsValid()
    {
        var doc = new Document("34110468000150", EDocumentType.CNPJ);
        Assert.IsTrue(doc.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("123455084")]
    [DataRow("451712345")]
    [DataRow("009876654")]
    public void ShouldReturnErrorWhenCPFIsInvalid(string cpf)
    {
        var doc = new Document(cpf, EDocumentType.CPF);
        Assert.IsFalse(doc.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCPFIsValid()
    {
        var doc = new Document("12345678915", EDocumentType.CPF);
        Assert.IsTrue(doc.IsValid);
    }
}