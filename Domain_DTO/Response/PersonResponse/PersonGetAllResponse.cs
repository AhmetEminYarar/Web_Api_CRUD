using Domain_DataBase.Domain_Entity;

namespace Domain_DTO.Response.PersonResponse
{
    public class PersonGetAllResponse
    {
        public string name { get; set; } = string.Empty;
        public string surname { get; set; } = string.Empty;
        public int age { get; set; }
        public string personimageurl { get; set; } = string.Empty;

        public List<PersonGetAllResponse> Map(List<Person> persons)
        {
            List<PersonGetAllResponse> response = new List<PersonGetAllResponse>();
            foreach (var person in persons)
            {
                PersonGetAllResponse PersonToDto = new PersonGetAllResponse()
                {
                    name = person.Name,
                    surname = person.Surname,
                    age = person.Age,
                    personimageurl = person.PersonImageURL,
                };
                response.Add(PersonToDto);
            }
            return response;
        }
    }
}
