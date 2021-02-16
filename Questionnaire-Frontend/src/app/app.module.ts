import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";

import { AppComponent } from "./app.component";

import { NavbarComponent } from "./navbar/navbar.component";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { LoginComponent } from "./login/login.component";

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    DashboardComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot([
    { path: "Home", component: DashboardComponent },
    { path: "login", component: LoginComponent },
    { path: "**", redirectTo: "/Home", pathMatch: "full" },
], { relativeLinkResolution: 'legacy' }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
