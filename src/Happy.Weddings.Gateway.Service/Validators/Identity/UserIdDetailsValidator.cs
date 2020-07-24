using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Identity;

namespace Happy.Weddings.Gateway.Service.Validators.Identity
{
    public class UserIdDetailsValidator : AbstractValidator<UserIdDetails>
    {
        public UserIdDetailsValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
