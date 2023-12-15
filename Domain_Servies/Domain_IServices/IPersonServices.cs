using Domain_DataBase.Domain_Entity;
using Microsoft.AspNetCore.Http;

namespace Domain_Servies.Domain_IServices
{
    public interface IPersonServices
    {
        Task<long> CreateAsync(Person person, IFormFile formFile);
        Task<long> UpdateAsync(Person person, IFormFile formFile);
        Task<long> DeleteAsync(Person person);
        Task<Person> GetByIdAsync(long id);
        Task<List<Person>> GetAll();
    }
}
