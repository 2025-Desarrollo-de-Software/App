import { AuthService } from '@abp/ng.core';
import { ToasterService } from '@abp/ng.theme.shared';
import { Component } from '@angular/core';
import { CitySearch } from '@proxy';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated;
  }

  cities: CitySearch.CityDto[] = []; // ← Array de CityDto
  searchText: string = '';
  loading: boolean = false;

  constructor(
    private authService: AuthService,
    private cityService: CitySearch.CitySearchService,
    private toasterService: ToasterService
  ) {}

  login() {
    this.authService.navigateToLogin();
  }

  search(): void {
    if (!this.hasLoggedIn) {
      this.toasterService.warn('Debes iniciar sesión para buscar ciudades');
      return;
    }

    if (!this.searchText || this.searchText.trim().length < 3) {
      this.toasterService.warn('Ingresa al menos 3 caracteres');
      return;
    }

    this.loading = true;
    this.cities = [];

    console.log('🔍 Buscando:', this.searchText);

    this.cityService.search(this.searchText, 10).subscribe({
      next: (response: CitySearch.CitySearchResultDto) => {
        console.log('✅ Respuesta completa:', response);
        
        // 👇 ACCEDER CORRECTAMENTE A LA PROPIEDAD CITIES
        if (response && response.cities) {
          this.cities = response.cities;
          console.log(`🏙️ Encontradas ${this.cities.length} ciudades`);
        } else {
          this.cities = [];
          console.log('❌ No se encontró la propiedad cities en la respuesta');
        }

        this.loading = false;
        
        if (this.cities.length === 0) {
          this.toasterService.info('No se encontraron ciudades');
        } else {
          this.toasterService.success(`Encontradas ${this.cities.length} ciudades`);
        }
      },
      error: (error) => {
        console.error('❌ Error:', error);
        this.toasterService.error('Error al buscar ciudades');
        this.loading = false;
      }
    });
  }

  clearSearch(): void {
    this.searchText = '';
    this.cities = [];
  }
}