import { Component, OnInit, Output } from '@angular/core';
import { ElasticServiceService } from '../service/elastic-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  
  
  constructor() { }

  ngOnInit(): void {
  }

  public query(query:string){
    ElasticServiceService.query = query;
  }

}
