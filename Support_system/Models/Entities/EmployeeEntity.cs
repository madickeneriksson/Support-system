
using System.ComponentModel.DataAnnotations;


namespace Support_system.Models.Entities
{
    internal class EmployeeEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [StringLength(100)]
        public string Email { get; set; } = null!;

    

    }
}
