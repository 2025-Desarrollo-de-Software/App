using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace TripGo.Destinations
{
    public class DestinationDTO : AuditedEntityDto<Guid>
    {
        public string Nombre { get; set; }
        public int Poblacion { get; set; }
        public string Foto { get; set; }
        public string Pais { get; set; }
        public string Coordenadas { get; set; }
        public int CantidadBusquedas { get; set; }
    }
}
