import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountService } from './services/account.service';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { MainPageComponent } from './views/main-page/main-page.component';
import { HeaderComponent } from './views/header/header.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule, NgModel } from '@angular/forms';
import { TableComponent } from './views/table/table.component';
import { FiltersComponent } from './views/table/filters/filters.component';
import { ModalComponent } from './views/table/modal/modal.component';
import { FiltersModalComponent } from './views/table/filters/filters-modal/filters-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    HeaderComponent,
    TableComponent,
    FiltersComponent,
    ModalComponent,
    FiltersModalComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    NgSelectModule,
    FormsModule
  ],
  providers: [AccountService],
  bootstrap: [AppComponent]
})
export class AppModule { }
