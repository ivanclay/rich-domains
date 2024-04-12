using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Address _address;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("12345678915", EDocumentType.CPF);
            _email = new Email("batman@gothan.com");
            _address = new Address("Rua 1", "1", "Legal", "Gothan", "Gothan", "USA", "1000");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }

         [TestMethod]
        public void ShouldReturnErrorWhenHaveActiveSubscription()
        {
            var payment = new PayPalPayment(
                                "123456",
                                DateTime.Now,
                                DateTime.Now.AddDays(5),
                                10,
                                10,
                                _address,
                                "WAYNE CORP",
                                _document,
                                _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsFalse(_student.IsValid);
        }      

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var payment = new PayPalPayment(
                                "123456",
                                DateTime.Now,
                                DateTime.Now.AddDays(5),
                                10,
                                10,
                                _address,
                                "WAYNE CORP",
                                _document,
                                _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
        }           
    }
}