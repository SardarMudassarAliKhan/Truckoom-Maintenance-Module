using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Truckoom_Maintenance_BAL.IMaintananceActivityService;
using Truckoom_Maintenance_DAL.IRepositories;
using Truckoom_Maintenance_DAL.Model;

namespace Truckoom_Maintenance_BAL.MaintenanceActivityService
{
    public class ServiceMaintenanceActivity : IServiceMaintenanceActivity<MaintenanceActivity>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ServiceMaintenanceActivity(
            UserManager<IdentityUser> userManager,
            IUnitOfWork unitOfWork,
          IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Add(MaintenanceActivity entity)
        {
            var LoggedInUserId = _httpContextAccessor.HttpContext.User;
            var user = await _userManager.GetUserAsync(LoggedInUserId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            entity.CreatorUserId = user.Id;
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedBy = user.Id;

            await _unitOfWork.Repository<MaintenanceActivity>().Add(entity);
            await _unitOfWork.Complete();
        }

        public async Task Delete(MaintenanceActivity entity)
        {
            var LoggedInUserId = _httpContextAccessor.HttpContext.User;
            var user = await _userManager.GetUserAsync(LoggedInUserId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            entity.CreatorUserId = user.Id;
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedBy = user.Id;
            var activity = await _unitOfWork.Repository<MaintenanceActivity>().GetByIdAsync(entity.Id);
            if (activity == null)
            {
                throw new KeyNotFoundException("Activity not found.");
            }

            await _unitOfWork.Repository<MaintenanceActivity>().Delete(activity);
            await _unitOfWork.Complete();
        }

        public async Task<MaintenanceActivity> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<MaintenanceActivity>().GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<MaintenanceActivity>> ListAllAsync()
        {
            var LoggedInUserId = _httpContextAccessor.HttpContext.User;
            var user = await _userManager.GetUserAsync(LoggedInUserId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }
            return await _unitOfWork.Repository<MaintenanceActivity>().ListAllAsync(user.Id);
        }

        public async Task Update(MaintenanceActivity entity)
        {
            var LoggedInUserId = _httpContextAccessor.HttpContext.User;
            var user = await _userManager.GetUserAsync(LoggedInUserId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            var existingActivity = await _unitOfWork.Repository<MaintenanceActivity>().GetByIdAsync(entity.Id);
            if (existingActivity == null)
            {
                throw new KeyNotFoundException("Activity not found.");
            }

            existingActivity.VehicleNumber = entity.VehicleNumber;
            existingActivity.MaintenanceType = entity.MaintenanceType;
            existingActivity.ActivityDate = entity.ActivityDate;
            existingActivity.Description = entity.Description;
            existingActivity.Notes = entity.Notes;
            entity.CreatorUserId = user.Id;
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedBy = user.Id;

            await _unitOfWork.Repository<MaintenanceActivity>().Update(existingActivity);
            await _unitOfWork.Complete();
        }
    }
}
