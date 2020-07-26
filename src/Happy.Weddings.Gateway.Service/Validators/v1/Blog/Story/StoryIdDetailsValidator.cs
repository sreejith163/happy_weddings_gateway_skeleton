using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Blog;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Blog.Story
{
    public class StoryIdDetailsValidator : AbstractValidator<StoryIdDetails>
    {
        public StoryIdDetailsValidator()
        {
            RuleFor(x => x.StoryId).NotEmpty();
        }
    }
}
