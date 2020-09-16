import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";

import { AppComponent } from './app.component';

import { NavbarComponent } from './navbar/navbar.component';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    DashboardComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "Home", component: DashboardComponent },

      { path: "**", redirectTo: '/Home', pathMatch: 'full' }, //for 404 page not found.
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
