import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import ptBr from '@angular/common/locales/pt';
import { CurrencyPipe, registerLocaleData } from '@angular/common';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CalculatorComponent } from './calculator/calculator.component';

registerLocaleData(ptBr);

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CalculatorComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: CalculatorComponent, pathMatch: 'full' },
    ])
  ],
  providers: [
    {provide: LOCALE_ID, useValue: 'pt' },
    CurrencyPipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
