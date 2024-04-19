using Truckoom_Maintenance_DAL.Model;

namespace Truckoom_Maintenance_BAL.IMaintananceActivityService
{
    public interface IServiceMaintenanceActivity<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
