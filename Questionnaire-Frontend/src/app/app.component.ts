import { Component } from "@angular/core";

@Component({
  selector: "app-root",
  template: `
    <navbar></navbar>
    <main role="main">
      <!-- style="padding-top: 4.5rem;" - for fixed top -->
      <router-outlet></router-outlet>
    </main>
    <footer class="container footer">
      <p>&copy; Questionnaire.io 2020 - Terence Frade Project</p>
    </footer>
  `,
  styles: [],
})
export class AppComponent {
  title = "Questionnaire-Frontend";
}
