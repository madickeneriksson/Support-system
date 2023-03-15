using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support_system.Models
{
    internal class Comments
    {
        public int Id { get; set; }
        public string TitleComment { get; set; } = null!;

        public string DescriptionComment { get; set; } = null!;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
