﻿using FluentValidation;
using System.ComponentModel.DataAnnotations;
using static LemadDb.Data.Status;

namespace LemadWeb.ViewModels.Product
{
    public class TechnicalChiefViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(dataType: DataType.Currency)]
        public decimal Price { get; set; }

        public byte Discount { get; set; }

        [Required]
        public ProductStatus Status { get; set; }
    }

    public class TechnicalChiefValidator : AbstractValidator<TechnicalChiefViewModel>
    {
        public TechnicalChiefValidator()
        {
            RuleFor(e => e.FirstName)
                .NotEmpty()
                .WithMessage("The firstname cannot be empty!");

            RuleFor(e => e.LastName)
                .NotEmpty()
                .WithMessage("The lastname cannot be empty!");

            RuleFor(e => e.Price)
                .NotEmpty().WithMessage("The price cannot be empty!")
                .GreaterThan(0).WithMessage("The price must be higher than 0.0$");

            RuleFor(e => e.Discount)
                .NotEmpty().WithMessage("The discount cannot be empty!")
                .When(e => e.Discount >= 0 && e.Discount <= 100).WithMessage("The discount must be greater or equal and 0 and less or equal than 100");
        }
    }
}