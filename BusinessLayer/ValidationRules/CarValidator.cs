using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
 

    public class CarValidator : AbstractValidator<Car>
    {

        public CarValidator()
        {
            RuleFor(x => x.carName).NotEmpty().WithMessage("Car name cant be empty")
                                        .MinimumLength(3).WithMessage("Car name must be greater than 3")
                                        .MaximumLength(30).WithMessage("Car name must be less than 30");
        }




    }
}
