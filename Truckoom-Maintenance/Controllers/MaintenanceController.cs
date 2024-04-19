using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Truckoom_Maintenance.DTOS;
using Truckoom_Maintenance_BAL.IMaintananceActivityService;
using Truckoom_Maintenance_DAL.Model;

namespace Truckoom_Maintenance.Controllers
{
    [Authorize]
    public class MaintenanceController : Controller
    {
        private readonly IServiceMaintenanceActivity<MaintenanceActivity> _serviceMaintenanceActivity;
        private readonly IMapper _mapper;

        public MaintenanceController(
            IServiceMaintenanceActivity<MaintenanceActivity> serviceMaintenanceActivity,
            IMapper mapper)
        {
            _serviceMaintenanceActivity = serviceMaintenanceActivity;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var activities = await _serviceMaintenanceActivity.ListAllAsync();
            return View(activities);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var activity = await _serviceMaintenanceActivity.GetByIdAsync(id);
            if (activity == null)
            {
                return NotFound(); // Return a 404 Not Found response if activity is not found
            }

            var activityDto = _mapper.Map<MaintenanceActivityEditDto>(activity);
            return View(activityDto); // Render the Details view with activity data
        }

        public IActionResult Create()
        {
            var activityDto = new MaintenanceActivityDto(); // Instantiate a new MaintenanceActivityDto
            return View(activityDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MaintenanceActivityDto activityDto)
        {
            if (ModelState.IsValid)
            {
                var activityEntity = _mapper.Map<MaintenanceActivity>(activityDto);
                await _serviceMaintenanceActivity.Add(activityEntity);
                return RedirectToAction(nameof(Index));
            }

            return View(activityDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var activity = await _serviceMaintenanceActivity.GetByIdAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            var activityDto = _mapper.Map<MaintenanceActivityEditDto>(activity);
            return View(activityDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MaintenanceActivityEditDto activityDto)
        {
            if (id != activityDto.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var activityEntity = _mapper.Map<MaintenanceActivity>(activityDto);
                try
                {
                    await _serviceMaintenanceActivity.Update(activityEntity);
                    return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
                }
                catch
                {
                    return NotFound();
                }
            }

            // If ModelState is not valid, return to the Edit view with validation errors
            return View(activityDto);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var activity = await _serviceMaintenanceActivity.GetByIdAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            var activityDto = _mapper.Map<MaintenanceActivityDeleteDto>(activity);
            return View(activityDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity = await _serviceMaintenanceActivity.GetByIdAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            try
            {
                await _serviceMaintenanceActivity.Delete(activity);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately, such as logging or displaying an error message
                return StatusCode(500, "An error occurred while deleting the activity.");
            }
        }
    }
}
