
using System.ComponentModel.DataAnnotations;


namespace Support_system.Models.Entities
{
    internal class StatusEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string? NotStarted { get; set; } = null!;

        [StringLength(20)]
        public string? Started { get; set; } = null!;

        [StringLength(20)]
        public string? Finished { get; set; } = null!;
        [Required]
        public int CaseId { get; set; } 
        public CaseEntity Cases { get; set; } = null!;


    }
}
