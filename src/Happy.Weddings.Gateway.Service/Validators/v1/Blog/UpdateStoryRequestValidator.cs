using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Blog;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Blog
{
    public class UpdateStoryRequestValidator : AbstractValidator<UpdateStoryRequest>
    {
        public UpdateStoryRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
