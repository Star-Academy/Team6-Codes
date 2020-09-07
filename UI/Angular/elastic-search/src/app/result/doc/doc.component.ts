import { Component, OnInit, Input } from '@angular/core';
import { Document } from '../models/Document';

@Component({
  selector: 'app-doc',
  templateUrl: './doc.component.html',
  styleUrls: ['./doc.component.scss']
})
export class DocComponent implements OnInit {

  @Input()
  public doc:Document;
  
  constructor() {
  }

  ngOnInit(): void {
  }

}
