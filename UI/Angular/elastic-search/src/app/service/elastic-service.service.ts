import { Injectable } from '@angular/core';
import {Document} from'../result/models/Document';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ElasticServiceService {
  static query:string;
  constructor(private http: HttpClient) { }

  public async getDocs(): Promise<Document[]> {
    return new Promise<Document[]>((resolve) => {
      this.http.get(`https://localhost:5001/Search/Search?query=${ElasticServiceService.query}`).subscribe((result: Document[]) => {
        resolve(result);
      });
    });
  }
}
