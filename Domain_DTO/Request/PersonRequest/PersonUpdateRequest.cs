using Domain_DataBase.Domain_Entity;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Domain_DTO.Request.PersonRequest
{
    public class PersonUpdateRequest
    {
        public long id { get; set; }
        public string name { get; set; } = string.Empty;
        public string surname { get; set; } = string.Empty;
        public int age { get; set; }
        public IFormFile personmageurl { get; set; }

        public Person Map(PersonUpdateRequest person)
        {
            Person newPerson = new Person()
            {
                Id = person.id,
                Name = person.name,
                Surname = person.surname,
                Age = person.age,
            };
            return newPerson;
        }
    }
    public class PersonUpdateRequestValidator : AbstractValidator<PersonUpdateRequest>
    {
        public PersonUpdateRequestValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty().MinimumLength(5).MaximumLength(50).WithMessage("Hata!!!!!!(Name)");
            RuleFor(x => x.surname)
                .NotEmpty().MinimumLength(5).MaximumLength(50).WithMessage("Hata!!!!!!(surname)");
            RuleFor(x => x.age)
                .NotEmpty().WithMessage("Hata!!!!!!(age)");
        }
    }
}
