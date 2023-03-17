
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Support_system.Models.Entities
{
    internal class CaseEntity
    {
   

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string CaseTitle { get; set; } = null!;

        [StringLength(200)]
        public string Description { get; set; } = null!;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [StringLength(200)]
        public string? UpdateComment { get; set; } = null!;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

  

        public ICollection<CustomerEntity> Customers { get; set; } = new HashSet<CustomerEntity>();
        public ICollection<AddressEntity> Addresses { get; set; } = new HashSet<AddressEntity>();
        public ICollection<CommentEntity> Comments { get; set; } = new HashSet<CommentEntity>();
        public ICollection<StatusEntity> Statuses { get; set; } = new HashSet<StatusEntity>();





    }


}
