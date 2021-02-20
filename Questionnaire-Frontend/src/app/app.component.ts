import { Component } from "@angular/core";

@Component({
  selector: "app-root",
  template: ` <navbar></navbar>
    <main role="main">
      <!-- style="padding-top: 5rem;" - for fixed top -->
      <router-outlet></router-outlet>
    </main>
    <footer class="container footer text-muted">
      <p>&copy; Questionnaire.io 2021 - Terence Frade Project</p>
    </footer>`,
  styles: [],
})
export class AppComponent {
  title = "Questionnaire-Frontend";
}
