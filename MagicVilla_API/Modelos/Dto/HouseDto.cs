using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Modelos.Dto
{
    public class houseDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int HouseNumber { get; set; }
        public string? HouseName { get; set;}
        public string? HouseDescription { get; set;}

        public string? HouseColor { get; set; }
    }
}
