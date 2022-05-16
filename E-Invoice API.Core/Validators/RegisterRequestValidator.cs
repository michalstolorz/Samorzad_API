﻿using E_Invoice_API.Core.DTO.Request;
using E_Invoice_API.Core.Exceptions;
using FluentValidation;

namespace E_Invoice_API.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .OnAnyFailure(x =>
                {
                    throw new ValidatorException(ErrorCodes.InvalidParameter, $"Parameter {nameof(x.Email)} is invalid.");
                });

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .OnAnyFailure(x =>
                {
                    throw new ValidatorException(ErrorCodes.InvalidParameter, $"Parameter {nameof(x.FirstName)} is invalid.");
                });

            RuleFor(x => x.LastName)
                .NotEmpty()
                .OnAnyFailure(x =>
                {
                    throw new ValidatorException(ErrorCodes.InvalidParameter, $"Parameter {nameof(x.LastName)} is invalid.");
                });

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\+[0-9]{1,3} ?\d{4,12}$")
                .OnAnyFailure(x =>
                {
                    throw new ValidatorException(ErrorCodes.InvalidParameter, $"Parameter {nameof(x.PhoneNumber)} is invalid.");
                });
        }
    }
}
