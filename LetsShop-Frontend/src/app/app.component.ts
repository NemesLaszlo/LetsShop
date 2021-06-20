import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Pagination } from './_models/pagination';
import { Product } from './_models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  baseUrl = environment.apiUrl
  title = 'LetsShop-Frontend';
  products: Product[];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get(this.baseUrl + 'products?pageSize=50').subscribe((response: Pagination) => {
      this.products = response.data;
    }, error => {
      console.log(error);
    })
  }

}
