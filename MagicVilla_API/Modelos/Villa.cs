﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_API.Modelos
{
    public class Villa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FechaCrecion { get; set; }
        [Required]
        public double Tarifa { get; set;}
        
        public string Detalle  { get; set;}
        public int Ocupantes { get; set; }
        public int MetrosCuadrados { get; set; }
        public string Amenidad { get; set; }
        public string ImgURL { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
