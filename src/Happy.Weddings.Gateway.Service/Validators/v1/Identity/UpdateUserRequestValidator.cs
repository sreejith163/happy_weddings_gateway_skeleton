using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Identity;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Identity
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
