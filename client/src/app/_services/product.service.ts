import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getProducts() {
    return this.http.get(this.baseUrl + 'products');
  }

  getProduct(productId: number) {
    return this.http.get(this.baseUrl + `products/${productId}`);
  }
}
