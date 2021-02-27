import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { HomeComponent } from "./components/home/home.component";
import { QuestionnaireComponent } from "./components/questionnaire/questionnaire.component";

const routes: Routes = [];

@NgModule({
  imports: [
    RouterModule.forRoot(
      [
        { path: "Home", component: HomeComponent },
        { path: "Questionnaires", component: QuestionnaireComponent },
        { path: "**", redirectTo: "/Home", pathMatch: "full" },
      ],
      { relativeLinkResolution: "legacy" }
    ),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
