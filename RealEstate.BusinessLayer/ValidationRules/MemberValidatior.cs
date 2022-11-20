using FluentValidation;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BusinessLayer.ValidationRules
{
    public class MemberValidatior:AbstractValidator<Member>
    {
        public MemberValidatior()
        {
            RuleFor(x => x.MemberName).NotEmpty().WithMessage("Üye adını giriniz...");
            RuleFor(x => x.MemberName).MinimumLength(3).WithMessage("Üye adı 3 karakterden az olamaz...");
            RuleFor(x => x.MemberName).MaximumLength(50).WithMessage("Üye adı 50 karakterden fazla olamaz...");

            RuleFor(x => x.MemberSurname).NotEmpty().WithMessage("Üye soyadını giriniz...");

            
        }
    }
}
