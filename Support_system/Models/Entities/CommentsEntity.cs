using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support_system.Models.Entities
{
    internal class CommentsEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string? TitleComment { get; set; } = null!;

        [StringLength(200)]
        public string? DescriptionComment { get; set; } = null!;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int CaseId { get; set; }
        public CaseEntity Cases { get; set; } = null!;
    }
}
