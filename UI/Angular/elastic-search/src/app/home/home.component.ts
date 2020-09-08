import { Component, OnInit, Output } from '@angular/core';
import { ElasticServiceService } from '../service/elastic-service.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {



  constructor(private service: ElasticServiceService) { }

  ngOnInit(): void {
  }

  public query(value: string) {
    this.service.query = value;
  }
  
}
