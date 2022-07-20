using Curso.ComercioElectronico.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curso.ComercioElectronico.Domain.Entities
{
    public class DeliveryMethod 
    {
        [Key]
        public string Id { get; set; }
        [Required, MaxLength(50)]
        public string NameUser { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string MethodPay { get; set; }
        [Required]
        public string CestaItemId { get; set; }
        [ForeignKey("CestaItemId")]
        public CestaItem CestaItem { get; set; }
    }
}
