using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void TestMetod1(){
            var student = new Student("André","Balta","123456","andre@balta.io");
        }                
    }
}