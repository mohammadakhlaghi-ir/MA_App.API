using FluentValidation;
using MA_App.Application.AppInfos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_App.Application.AppInfos.Validators
{
    public class AppInfoDtoValidator : AbstractValidator<AppInfoDto>
    {
        public AppInfoDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(50);

            RuleFor(x => x.Description)
                .MaximumLength(200);

            RuleFor(x => x.Created)
                .NotEmpty().WithMessage("Created date is required");

            RuleFor(x => x.Logo)
                .NotEmpty();

            RuleFor(x => x.Favicon)
                .NotEmpty();

            RuleFor(x => x.Language)
                .NotEmpty();

            RuleFor(x => x.Version)
                .NotEmpty();
        }
    }
}
