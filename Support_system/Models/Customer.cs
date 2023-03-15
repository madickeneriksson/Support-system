using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support_system.Models
{
    internal class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string CaseTitle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? UpdateComment { get; set; } 
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
