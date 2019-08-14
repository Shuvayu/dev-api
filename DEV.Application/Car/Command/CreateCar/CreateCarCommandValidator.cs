using FluentValidation;
using System;

namespace DEV.Application.Car.Command.CreateCar
{
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(x => x.Colour).NotEmpty();
            RuleFor(x => x.CountryManufactured).NotEmpty();
            RuleFor(x => x.Price).NotEmpty()
                .GreaterThan(0)
                .ScalePrecision(0, 14);
            RuleFor(x => x.Year).NotEmpty()
                .GreaterThanOrEqualTo(1908)
                .LessThanOrEqualTo(DateTime.Today.Year)
                .ScalePrecision(1, 4)
                .WithMessage("The first production car was created in 1908 and the year must be less equal to this year.");
            RuleFor(x => x.Model).NotEmpty();
            RuleFor(x => x.Make).NotEmpty();
        }
    }
}
