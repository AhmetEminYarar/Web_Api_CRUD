using Domain_DataBase.Domain_Entity;

namespace Domain_DTO.Response.PersonResponse
{
    public class PersonGetByIdResponse
    {
        public long id { get; set; }
        public string name { get; set; } = string.Empty;
        public string surname { get; set; } = string.Empty;
        public int age { get; set; }
        public string personimageurl { get; set; } = string.Empty;
        public PersonGetByIdResponse Map(Person person)
        {
            this.id = person.Id;
            this.name = person.Name;
            this.age = person.Age;
            this.surname = person.Surname;
            this.personimageurl = person.PersonImageURL;
            return this;
        }
    }
}
