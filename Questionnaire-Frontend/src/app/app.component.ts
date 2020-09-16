import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
  <navbar></navbar>
  <main role="main" style="padding-top: 4.5rem;">
    <router-outlet></router-outlet>
  </main>
  <footer class="container footer">
  <p>&copy; Warg 2019 - Rodgers Training Project</p>
  </footer>
  `,
  styles: []
})
export class AppComponent {
  title = 'Questionnaire-Frontend';
}
