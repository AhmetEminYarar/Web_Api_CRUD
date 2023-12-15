using Domain_DataBase.Domain_Context;

namespace Domain_DataBase.Domain_UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appdbcontext;

        public UnitOfWork(AppDbContext appdbcontext)
        {
            _appdbcontext = appdbcontext;
        }
        public async Task BeginTranssections()
        {
            await _appdbcontext.Database.BeginTransactionAsync();
        }
        public async Task CommitTranssections()
        {
            await _appdbcontext.Database.CommitTransactionAsync();
        }
        public async Task RollbackTranssections()
        {
            await _appdbcontext.Database.RollbackTransactionAsync();
        }
    }
}
