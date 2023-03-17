using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support_system.Models
{
    internal class Case
    {
        public int Id { get; set; } 
        public string CaseTitle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? UpdateComment { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
