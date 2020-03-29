import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { slideInAnimation, slideInHomeAnimation } from './animations/animations';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  animations: [ slideInHomeAnimation, slideInAnimation ]
})
export class AppComponent {
  title = 'app';

  constructor() {
  }

  getAnimationData(outlet: RouterOutlet) {
    return outlet && outlet.activatedRouteData && outlet.activatedRouteData['animation'];
  }
}
