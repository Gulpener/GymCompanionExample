import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { DeviceListComponent } from './device-list/device-list.component';
import { DeviceService } from './services/device-service';
import { DeviceEditComponent } from './device-edit/device-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    DeviceListComponent,
    DeviceEditComponent,    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule ,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'device-list', component: DeviceListComponent },
      { path: 'device-edit', component: DeviceEditComponent },
      { path: 'device-add', component: DeviceEditComponent },
    ])
  ],
  providers: [DeviceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
