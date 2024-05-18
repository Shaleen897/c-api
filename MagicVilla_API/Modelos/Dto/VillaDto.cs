using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Modelos.Dto
{
    public class VillaDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public double Tarifa { get; set; }

        public string Detalle { get; set; }
        public int Ocupantes { get; set; }
        public int MetrosCuadrados { get; set; }
        public string Amenidad { get; set; }
        public string ImgURL { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
