﻿using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Blog;

namespace Happy.Weddings.Gateway.Service.Validators.Blog
{
    public class CreateStoryRequestValidator : AbstractValidator<CreateStoryRequest>
    {
        public CreateStoryRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
