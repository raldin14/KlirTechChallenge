import { Component, OnInit } from '@angular/core';
import { ShoppingCart } from 'src/app/models/shoppingcart';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  constructor(public productService: ProductsService) { }

  ngOnInit() {
    this.productService.getProducts();
    this.productService.getPromotion();
  }

  addingToCart(item: string){
    this.productService.addingItems(item);
  }

}
