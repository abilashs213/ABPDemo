import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44322/',
  redirectUri: baseUrl,
  clientId: 'Angular',
  responseType: 'code',
  scope:
    'offline_access openid profile email phone AccountService IdentityService AdministrationService SaasService ProductService',
  requireHttps: true,
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Demo',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44325',
      rootNamespace: 'ABP.Demo',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
    ProductService: {
      url: 'https://localhost:44325',
      rootNamespace: 'ABP.Demo',
    },
  },
  remoteEnv: {
    url: '/getEnvConfig',
    mergeStrategy: 'overwrite',
  },
} as Environment;
