using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support_system.Models.Entities
{
    internal class CommentEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string? UpdateComment { get; set; } = null!;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<CustomerEntity> Customers { get; set; } = new HashSet<CustomerEntity>();
    }
}
