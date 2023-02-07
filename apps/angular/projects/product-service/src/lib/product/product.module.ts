import { NgModule } from '@angular/core';
import {
  NgbCollapseModule,
  NgbDatepickerModule,
  NgbDropdownModule,
} from '@ng-bootstrap/ng-bootstrap';
import { PageModule } from '@abp/ng.components/page';
import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { ProductRoutingModule } from './product-routing.module';
import { ProductComponent } from './product.component';
import { AdvancedEntityFiltersModule } from '@volo/abp.commercial.ng.ui';

@NgModule({
  declarations: [ProductComponent],
  imports: [
    CoreModule,
    ThemeSharedModule,
    ProductRoutingModule,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbDropdownModule,
    PageModule,
    AdvancedEntityFiltersModule,
  ],
})
export class ProductModule {}
