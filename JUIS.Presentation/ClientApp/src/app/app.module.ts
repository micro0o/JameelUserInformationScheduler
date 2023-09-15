import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { CommonModule, NgIf } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { NgIconsModule } from '@ng-icons/core';
import { ionLocationOutline, ionCallOutline, ionEllipse, ionCloudOffline, ionCloudDone } from '@ng-icons/ionicons';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import {
  NgxMaskDirective, NgxMaskPipe, provideNgxMask
} from 'ngx-mask';
import { AlertModule } from 'ngx-bootstrap/alert';
import { HttpErrorsInterceptor } from './interceptors/http-errors.interceptor';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgIf,
    BrowserAnimationsModule,
    TooltipModule.forRoot(),
    NgIconsModule.withIcons({ ionLocationOutline, ionCallOutline, ionEllipse, ionCloudOffline, ionCloudDone }),
    BsDatepickerModule.forRoot(),
    CommonModule,
    NgxMaskDirective, NgxMaskPipe, AlertModule.forRoot()
  ],
  providers: [provideNgxMask(), { provide: HTTP_INTERCEPTORS, useClass: HttpErrorsInterceptor, multi: true },],
  bootstrap: [AppComponent]
})
export class AppModule { }
