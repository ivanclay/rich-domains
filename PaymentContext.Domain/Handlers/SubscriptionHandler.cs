using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers;
public class SubscriptionHandler : 
    Notifiable<Notification>,
    IHandler<CreateBoletoSubscriptionCommand>
{
    private readonly IStudentRepository _repository;
    private readonly IEmailService _emailService;
    public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
    {
        _repository = repository;
        _emailService = emailService;
    }
    public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
    {
        //Fail fast validation
        command.Validate();
        if(!command.IsValid){
            AddNotifications(command);
            return new CommandResult(false, "Unsuccessful subscription!");
        }

        //verify document;
        if(_repository.DocumentExists(command.Document))
            AddNotification("Document", "Documento em uso");
        
        //verify e-mail;
        if(_repository.EmailExists(command.Email))
            AddNotification("Email", "Email em uso");
        
        //create VOs
        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document, EDocumentType.CPF);
        var email = new Email(command.Email);
        var address = new Address(
                command.Street,
                command.Number,
                command.Neighborhood,
                command.City,
                command.State,
                command.Country,
                command.ZipCode);

        //create entities
        var student = new Student(name, document, email);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payment = new BoletoPayment(
                    command.BarCode,
                    command.BoletoNumber,
                    command.PaidDate,
                    command.ExpireDate,
                    command.Total,
                    command.TotalPaid,
                    address,
                    command.Payer,
                    new Document(command.PayerDocument, command.PayerDocumentType),
                    email);
        
        //Relationship
        subscription.AddPayment(payment);
        student.AddSubscription(subscription);                    

        //Group validations
        AddNotifications(name, document,email, address, student, subscription, payment);

        //Check validations
        if(!IsValid)
            return new CommandResult(false, "Subscription not created!");

        //save informations
        _repository.CreateSubscription(student);

        //send welcome e-mail
        _emailService.Send(
            student.Name.ToString(),
            student.Email.Address,
            "Welcome to system",
            "Your subscription was created!"
            );

        //return informations
        return new CommandResult(true, "Subscription successfully!");
    }

}