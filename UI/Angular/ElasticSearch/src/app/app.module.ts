import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ResultComponent } from './result/result.component';
import { DocComponent } from './result/doc/doc.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ResultComponent,
    DocComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
