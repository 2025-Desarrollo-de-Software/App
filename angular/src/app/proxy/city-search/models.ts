
export interface CityDto {
  id: number;
  name?: string;
  country?: string;
  latitude: number;
  longitude: number;
  population?: number;
}

export interface CitySearchResultDto {
  cities: CityDto[];
}

export interface CitySearchRequestDto {
  namePrefix?: string;
  limit: number;
  cities: CityDto[];
}
