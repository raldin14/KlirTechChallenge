import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Products } from '../models/products';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  myAppUrl = 'http://localhost:5000/';
  myApiUrl = 'api/Products/';
  itemList: Products[];

  constructor(private http: HttpClient) { }

  addProduct(product: Products): Observable<Products>{
    return this.http.post<Products>(this.myAppUrl + this.myApiUrl, product);//Metodo es al shopping cart
  }

  getProducts(){
    this.http.get(this.myAppUrl + this.myApiUrl).toPromise()
                  .then(data => {
                    this.itemList = data as Products[];
                  });
  }
}
