using System.ComponentModel.DataAnnotations;

namespace Truckoom_Maintenance.DTOS
{
    public class MaintenanceActivityEditDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vehicle Number is required.")]
        public string VehicleNumber { get; set; }

        [Required(ErrorMessage = "Maintenance Type is required.")]
        public string MaintenanceType { get; set; }

        [Required(ErrorMessage = "Activity Date is required.")]
        [DataType(DataType.Date)]
        public DateTime ActivityDate { get; set; }

        public string Description { get; set; }
        public string Notes { get; set; }
    }
}

