import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { StoreModule } from "./components/store/store.module"
import { StoreComponent } from "../app/components/store/store.component";
import { CheckoutComponent } from "./components/checkout/checkout.component";
import { CartDetailComponent } from "./components/cartDetail/cartDetail.component";
import { StoreFirstGuard } from "./storeFirst.guard";

@NgModule({
    declarations: [
        AppComponent,
    ],
    imports: [
        CommonModule,
        StoreModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'store', pathMatch: 'full' },
            {
                path: "store", component: StoreComponent,
                canActivate: [StoreFirstGuard]
            },
            {
                path: "cart", component: CartDetailComponent,
                canActivate: [StoreFirstGuard]
            },
            {
                path: "checkout", component: CheckoutComponent,
                canActivate: [StoreFirstGuard]
            },
           
        ])
    ],
    providers: [StoreFirstGuard]
})
export class AppModuleShared {
}
