import { Component, OnInit } from '@angular/core';
import { Document } from 'src/app/models/Document';

@Component({
  selector: 'app-doc',
  templateUrl: './doc.component.html',
  styleUrls: ['./doc.component.scss']
})
export class DocComponent implements OnInit {

  constructor() { }
  public doc: Document;

  ngOnInit(): void {
    
  }

}
