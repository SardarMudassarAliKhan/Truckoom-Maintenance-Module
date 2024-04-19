using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Truckoom_Maintenance_DAL.Model
{
    public class MaintenanceActivity : BaseEntity
    {
        [Required(ErrorMessage = "Vehicle Number is required.")]
        public string VehicleNumber { get; set; }

        [Required(ErrorMessage = "Maintenance Type is required.")]
        public string MaintenanceType { get; set; }

        [Required(ErrorMessage = "Activity Date is required.")]
        [DataType(DataType.Date)]
        public DateTime ActivityDate { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Notes is required.")]
        public string Notes { get; set; }

        public IdentityUser Users { get; set; }

        public string CreatorUserId { get; set; }
    }
}
