using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support_system.Models.Entities
{
    internal class StatusEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string NotStarted { get; set; } = "Ej Påbörjad";

        [StringLength(50)]
        public string Started { get; set; } = "Påbörjad";

        [StringLength(50)]
        public string Closed { get; set; } = "Avslutad";

        public ICollection<CustomerEntity> Customers { get; set; } = new HashSet<CustomerEntity>();


    }
}
