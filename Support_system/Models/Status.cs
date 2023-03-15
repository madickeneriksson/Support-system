using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support_system.Models
{
    internal class Status
    {
        public int Id { get; set; }
        public string? NotStarted { get; set; } = null!;
        public string? Started { get; set; } = null!;
        public string? Finished { get; set; } = null!;
    }
}
