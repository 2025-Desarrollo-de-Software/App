import type { CitySearchResultDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CitySearchService {
  apiName = 'Default';
  

  search = (namePrefix: string, limit: number = 10, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CitySearchResultDto>({
      method: 'POST',
      url: '/api/app/city-search/search',
      params: { namePrefix, limit },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
