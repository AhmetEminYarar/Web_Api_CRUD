using Domain_DataBase.Domain_Entity;
using Domain_DataBase.Domain_Repository;
using Domain_Servies.Domain_IServices;
using Microsoft.AspNetCore.Http;

namespace Domain_Servies.Domain_Services
{
    public class PesonServices : IPersonServices
    {
        private readonly IRepository<Person> _repository;
        public PesonServices(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public async Task<long> CreateAsync(Person person, IFormFile formFile)
        {
            if (formFile != null)
                if (formFile.Length > 0)
                {
                    var filePath = Path.Combine("wwwroot", "Image", Path.GetRandomFileName());
                    using (var stream = File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    person.PersonImageURL = filePath;
                }
            await _repository.CreateAsync(person);
            return person.Id;
        }

        public async Task<long> DeleteAsync(Person person)
        {
            await _repository.DeleteAsync(person);
            return person.Id;
        }

        public async Task<List<Person>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Person> GetByIdAsync(long id)
        {
            var response = await _repository.GetByIdAsync(id);
            if (response == null)
                throw new Exception("Hata(Services)");
            else
                return response;
        }

        public async Task<long> UpdateAsync(Person person, IFormFile fromFile)
        {
            if (fromFile != null)
                if (fromFile.Length > 0)
                {
                    var filePath = Path.Combine("wwwroot", "Image", Path.GetRandomFileName());
                    using (var stream = File.Create(filePath))
                    {
                        await fromFile.CopyToAsync(stream);
                    }
                    person.PersonImageURL = filePath;
                }
            await _repository.UpdateAsync(person);
            return person.Id;
        }
    }
}
