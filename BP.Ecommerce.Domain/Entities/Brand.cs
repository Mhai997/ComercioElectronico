using System.ComponentModel.DataAnnotations;

namespace Curso.ComercioElectronico.Domain.Entities
{
    public class Brand 
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        public bool Status { get; set; } = true;
    }
}
