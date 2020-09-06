import { Component, OnInit } from '@angular/core';
import { Document } from 'src/app/models/Document'

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.scss']
})
export class ResultComponent implements OnInit {

  public results: Document[]
  constructor() { }

  ngOnInit(): void {
    
  }

}
