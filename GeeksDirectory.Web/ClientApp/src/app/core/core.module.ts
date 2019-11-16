import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { SharedModule } from '@shared/shared.module';
import { PageNotFoundComponent } from './containers/page-not-found/page-not-found.component';
import { TopbarComponent } from './components/topbar/topbar.component';
import { LeftBarComponent } from './components/left-bar/left-bar.component';
import { RootLayoutComponent } from './containers/root-layout/root-layout.component';

@NgModule({
    declarations: [PageNotFoundComponent, TopbarComponent, LeftBarComponent, RootLayoutComponent],
    imports: [CommonModule, RouterModule, SharedModule],
    exports: [PageNotFoundComponent, TopbarComponent, LeftBarComponent, RootLayoutComponent]
})
export class CoreModule {}