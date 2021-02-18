import { Component } from "@angular/core";

@Component({
  selector: "app-root",
  template: `<navbar></navbar>
    <router-outlet>
      <home></home>
    </router-outlet>`,
  styles: [],
})
export class AppComponent {
  title = "Questionnaire-Frontend";
}
