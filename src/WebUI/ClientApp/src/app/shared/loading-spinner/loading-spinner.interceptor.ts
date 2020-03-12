import { Injectable } from "@angular/core";
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable } from "rxjs";
import { finalize } from "rxjs/operators";
import { LoadingSpinnerService } from "./loading-spinner.service";


@Injectable()
export class LoadingSpinnerInterceptor implements HttpInterceptor {

  activeRequests: number = 0;

  constructor(private loadingSpinnerService: LoadingSpinnerService) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (this.activeRequests === 0) {
      this.loadingSpinnerService.startLoading();
    }

    this.activeRequests++;
    return next.handle(request).pipe(
      finalize(() => {
        this.activeRequests--;
        if (this.activeRequests === 0) {
          this.loadingSpinnerService.stopLoading();
        }
      })
    )
  };

}