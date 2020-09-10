import { TestBed } from '@angular/core/testing';

import { ElasticServiceService } from './elastic-service.service';

describe('ElasticServiceService', () => {
  let service: ElasticServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ElasticServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
