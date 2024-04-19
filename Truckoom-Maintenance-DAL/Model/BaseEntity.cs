namespace Truckoom_Maintenance_DAL.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; } = false;
    }
}
