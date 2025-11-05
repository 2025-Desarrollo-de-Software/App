 import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44385/',
  redirectUri: baseUrl,
  clientId: 'TripGo_App',
  responseType: 'code',
  scope: 'offline_access TripGo',
  requireHttps: true,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'TripGo',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44385',
      rootNamespace: 'TripGo',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
