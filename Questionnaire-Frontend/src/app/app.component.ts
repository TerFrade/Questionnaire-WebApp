import { Component } from "@angular/core";

@Component({
  selector: "app-root",
  template: ` <navbar></navbar>
    <main role="main" class="container pt-4">
      <router-outlet></router-outlet>
      <hr class="mt-1" />
    </main>

    <footer class="container footer text-muted">
      <p>&copy; Questionnaire.io 2021 - Terence Frade Project</p>
    </footer>`,
  styles: [],
})
export class AppComponent {
  title = "Questionnaire-Frontend";
}
