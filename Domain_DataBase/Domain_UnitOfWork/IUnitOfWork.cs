namespace Domain_DataBase.Domain_UnitOfWork
{
    public interface IUnitOfWork
    {
        Task BeginTranssections();
        Task CommitTranssections();
        Task RollbackTranssections();
    }
}
