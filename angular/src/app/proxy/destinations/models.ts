import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateDestinationDto {
  nombre: string;
  pais: string;
  foto: string;
  poblacion: number;
  coordenadas: string;
  cantidadBusquedas: number;
}

export interface DestinationDTO extends AuditedEntityDto<string> {
  nombre?: string;
  poblacion: number;
  foto?: string;
  pais?: string;
  coordenadas?: string;
  cantidadBusquedas: number;
}
