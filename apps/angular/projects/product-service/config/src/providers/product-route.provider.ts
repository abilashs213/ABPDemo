import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eProductRouteNames } from '../enums/route-names';

export const PRODUCTS_PRODUCT_ROUTE_PROVIDER = [
    { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
    return () => {
        routes.add([
            {
                path: '/product-service/product',
                name: eProductRouteNames.Product,
                parentName: eProductRouteNames.ProductService,
                layout: eLayoutType.application,
                requiredPolicy: 'ProductService.Products',
            },
        ]);
    };
}
