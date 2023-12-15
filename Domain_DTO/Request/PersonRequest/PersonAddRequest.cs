using Domain_DataBase.Domain_Entity;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Domain_DTO.Request.PersonRequest
{
    public class PersonAddRequest
    {
        public string name { get; set; } = string.Empty;
        public string surname { get; set; } = string.Empty;
        public int age { get; set; }
        public IFormFile personimageurl { get; set; } 

        public Person Map(PersonAddRequest person)
        {
            Person newPerson = new Person()
            {
                Name = person.name,
                Surname = person.surname,
                Age = person.age,

            };
            return newPerson;
        }
    }
    public class PersonAddRequestValidator : AbstractValidator<PersonAddRequest>
    {
        public PersonAddRequestValidator()
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
