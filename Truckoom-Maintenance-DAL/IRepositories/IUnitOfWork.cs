using Truckoom_Maintenance_DAL.Model;

namespace Truckoom_Maintenance_DAL.IRepositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();
    }
}
