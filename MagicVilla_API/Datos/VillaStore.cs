using MagicVilla_API.Modelos.Dto;

namespace MagicVilla_API.Datos
{
    public class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto>
        {
          
                new VillaDto { Id = 1, Name = "Vista al amanecer", Ocupantes = 3, MetrosCuadrados = 50},
                new VillaDto { Id = 2, Name = "Vista a la playa", Ocupantes = 5, MetrosCuadrados = 80}
            
        };
    }
}
