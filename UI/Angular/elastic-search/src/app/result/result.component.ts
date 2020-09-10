import { Component, OnInit, Input } from '@angular/core';
import{ Document} from './models/Document';
import { ElasticServiceService } from '../service/elastic-service.service';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.scss']
})
export class ResultComponent implements OnInit {

  
  public docs:Document[] = []

  constructor(private service:ElasticServiceService) {
    
  }


  async ngOnInit() {
    
    this.docs = await this.service.getDocs();
  }

}
