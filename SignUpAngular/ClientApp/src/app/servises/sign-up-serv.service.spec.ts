import { TestBed } from '@angular/core/testing';

import { SignUpServService } from './sign-up-serv.service';

describe('SignUpServService', () => {
  let service: SignUpServService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SignUpServService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
