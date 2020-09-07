import { Component, OnInit, Input } from '@angular/core';
import{ Document} from './models/Document';
import{DocComponent} from './doc/doc.component';
import { HomeComponent } from '../home/home.component';
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
