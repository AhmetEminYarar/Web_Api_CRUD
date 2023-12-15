using Domain_DataBase.Domain_Context;
using Domain_DataBase.Domain_UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Domain_DataBase.Domain_Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _appdbcontext;
        private readonly IUnitOfWork _unitofwork;

        public Repository(AppDbContext appdbcontext, IUnitOfWork unitofwork)
        {
            _appdbcontext = appdbcontext;
            _unitofwork = unitofwork;
        }
        public async Task CreateAsync(T entity)
        {
            await _unitofwork.BeginTranssections();
            await _appdbcontext.Set<T>().AddAsync(entity);
            await _appdbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            await _unitofwork.BeginTranssections();
            _appdbcontext.Remove(entity);
            await _appdbcontext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _appdbcontext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _appdbcontext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            await _unitofwork.BeginTranssections();
            _appdbcontext.Set<T>().Update(entity);
            await _appdbcontext.SaveChangesAsync();
        }
    }
}
