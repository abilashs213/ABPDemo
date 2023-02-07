import { ModuleWithProviders, NgModule, NgModuleFactory } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { ProductServiceRoutingModule } from './product-service-routing.module';
import { ProductModule } from './product/product.module';

@NgModule({
  declarations: [],
  imports: [CoreModule, ThemeSharedModule, ProductServiceRoutingModule, ProductModule],
  exports: [ProductModule],
})
export class ProductServiceModule {
  static forChild(): ModuleWithProviders<ProductServiceModule> {
    return {
      ngModule: ProductServiceModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<ProductServiceModule> {
    return new LazyModuleFactory(ProductServiceModule.forChild());
  }
}
