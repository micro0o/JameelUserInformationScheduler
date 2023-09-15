import { TestBed } from '@angular/core/testing';

import { ServerCheckService } from './server-check.service';

describe('ServerCheckService', () => {
  let service: ServerCheckService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServerCheckService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
