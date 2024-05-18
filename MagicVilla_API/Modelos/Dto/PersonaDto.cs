using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Modelos.Dto
{
    public class PersonaDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string lastName { get; set; }
        public DateTime FechaCrecion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
