import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'CarMarketplace',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44352/',
    redirectUri: baseUrl,
    clientId: 'CarMarketplace_App',
    responseType: 'code',
    scope: 'offline_access CarMarketplace',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44352',
      rootNamespace: 'Dignite.CarMarketplace',
    },
    CarMarketplace: {
      url: 'https://localhost:44310',
      rootNamespace: 'Dignite.CarMarketplace',
    },
  },
} as Environment;
