using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Blog;
using Happy.Weddings.Gateway.Core.DTO.Identity;
using Happy.Weddings.Gateway.Service.Validators.v1.Blog;
using Happy.Weddings.Gateway.Service.Validators.v1.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Happy.Weddings.Gateway.API.Extensions
{
    /// <summary>
    /// Extension for adding fluent validators
    /// </summary>
    public static class FluentValidation
    {
        /// <summary>
        /// Adds the fluent validators.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddFluentAbstractValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UserIdDetails>, UserIdDetailsValidator>();
            services.AddTransient<IValidator<CreateUserRequest>, CreateUserRequestValidator>();
            services.AddTransient<IValidator<UpdateUserRequest>, UpdateUserRequestValidator>();

            services.AddTransient<IValidator<StoryIdDetails>, StoryIdDetailsValidator>();
            services.AddTransient<IValidator<CreateStoryRequest>, CreateStoryRequestValidator>();
            services.AddTransient<IValidator<UpdateStoryRequest>, UpdateStoryRequestValidator>();

            return services;
        }
    }
}
