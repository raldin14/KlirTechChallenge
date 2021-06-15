import { Component, OnInit } from '@angular/core';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-shoppingcart',
  templateUrl: './shoppingcart.component.html',
  styleUrls: ['./shoppingcart.component.css']
})
export class ShoppingcartComponent implements OnInit {

  constructor(public productService: ProductsService) { }

  ngOnInit() {
    this.productService.getCart();
  }

  deleteItem(id: number){
    if(confirm('Are you sure you want to delete this item?')){
      this.productService.deleteFromCart(id).subscribe(date => {
        this.productService.getCart();        
        confirm('Item deleted!');
      });
    }
  }
}
