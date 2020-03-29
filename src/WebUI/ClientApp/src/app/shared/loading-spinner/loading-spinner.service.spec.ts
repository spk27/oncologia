import { TestBed } from '@angular/core/testing';

import { LoadingSpinnerService } from './loading-spinner.service';
import { MaterialModule } from 'src/app/materialUI/angularMaterialModule';

describe('LoadingSpinnerService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [
      MaterialModule
    ]
  }));

  it('should be created', () => {
    const service: LoadingSpinnerService = TestBed.get(LoadingSpinnerService);
    expect(service).toBeTruthy();
  });
});
