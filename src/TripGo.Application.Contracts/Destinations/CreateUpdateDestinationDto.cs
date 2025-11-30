using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripGo.Destinations
{
    public class CreateUpdateDestinationDto
    {
        [Required]
        [StringLength(128)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(128)]
        public string Pais { get; set; } = string.Empty;

        [Required]
        [Url]
        public string Foto { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue)]
        public int Poblacion { get; set; }

        [Required]
        public string Coordenadas { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue)]
        public int CantidadBusquedas { get; set; } = 0;

    }
}
