using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Support_system.Models.Entities.CaseEntity;

namespace Support_system.Models
{
    internal class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string StreetName { get; set; } = null!;
        public string Postalcode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string CaseTitle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? UpdateComment { get; set; } 
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string NotStarted { get; set; } = "Ej Påbörjad";
        public string Started { get; set; } = "Påbörjad";
        public string Closed { get; set; } = "Avslutad";




    }
}
