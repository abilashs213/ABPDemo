import { ModuleWithProviders, NgModule } from '@angular/core';
import { PRODUCTS_PRODUCT_ROUTE_PROVIDER } from './providers/product-route.provider';
import { PRODUCT_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class ProductServiceConfigModule {
  static forRoot(): ModuleWithProviders<ProductServiceConfigModule> {
    return {
      ngModule: ProductServiceConfigModule,
      providers: [PRODUCT_ROUTE_PROVIDERS, PRODUCTS_PRODUCT_ROUTE_PROVIDER],
    };
  }
}
