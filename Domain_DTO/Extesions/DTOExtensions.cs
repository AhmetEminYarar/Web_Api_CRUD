using Domain_DTO.Request.PersonRequest;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Domain_DTO.Extesions
{
    public static class DTOExtensions
    {
        public static IServiceCollection LoadDtoExtensions(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<PersonAddRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<PersonUpdateRequestValidator>();

            return services;
        }





    }
}
