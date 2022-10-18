import { TestBed } from '@angular/core/testing';

import { TblUsrService } from './tbl-usr.service';

describe('TblUsrService', () => {
  let service: TblUsrService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TblUsrService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
