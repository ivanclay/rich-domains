﻿using Flunt.Validations;
using PaymentContext.Shared.ValueObject;

namespace PaymentContext.Domain.ValueObjects;
public class Email: ValueObject
{
    public Email(string address)
    {
        Address = address;
        
        AddNotifications(new Contract<Email>()
            .Requires()
            .IsEmail(Address, "Email.Address","Invalid e-mail"));
    }

    public string Address { get; set; }
}