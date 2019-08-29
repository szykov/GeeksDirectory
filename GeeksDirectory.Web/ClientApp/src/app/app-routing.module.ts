import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PageNotFoundComponent } from './shared/components';
import { GeekListComponent } from './components/geek-list/geek-list.component';
import { environment } from 'src/environments/environment';
import { GeekRegisterComponent } from './components/geek-register/geek-register.component';
import { GeekItemComponent } from './components/geek-item/geek-item.component';

const routes: Routes = [
    { path: '', component: GeekListComponent },
    { path: 'register', component: GeekRegisterComponent, pathMatch: 'full' },
    { path: 'profiles/:id', component: GeekItemComponent },
    { path: '**', component: PageNotFoundComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes, { enableTracing: environment.development })],
    exports: [RouterModule]
})
export class AppRoutingModule {}
