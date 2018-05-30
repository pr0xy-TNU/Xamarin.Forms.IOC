using AppDI.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using AppDIv2.Helper;

namespace AppDIv2.validation
{
    class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(ins => ins.FirstName)
                .Must(name => ValidateStringEmpty(name))
                .WithMessage(ValidationMessageError.FIELD_IS_EMPTY);

            RuleFor(ins => ins.LastName)
                .Must(lastName => ValidateStringEmpty(lastName))
                .WithMessage(ValidationMessageError.FIELD_IS_EMPTY);

            RuleFor(ins => ins.UserEmail)
                .Must(email => ValidateStringEmpty(email))
                .WithMessage(ValidationMessageError.FIELD_IS_EMPTY)
                .Must(email => ValidateEmail(email))
                .WithMessage(ValidationMessageError.ERROR_EMAIL);

            RuleFor(ins => ins.PhoneNumber)
                .Must(number => ValidateStringEmpty(number))
                .WithMessage(ValidationMessageError.FIELD_IS_EMPTY)
                .Must(number => ValidateNumber(number))
                .WithMessage(ValidationMessageError.ERROR_PHONE_NUMBER);

        }

        bool ValidateStringEmpty(string value) => !string.IsNullOrEmpty(value);
        bool ValidateEmail(string value) => value.Contains("@");
        bool ValidateNumber(string value) => value.Length == 10;
    }
}
