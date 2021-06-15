import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Products } from '../models/products';
import { Promotions } from '../models/promotions';
import { ShoppingCart } from '../models/shoppingcart';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  myAppUrl = 'http://localhost:5000/';

  productApiUrl = 'api/Products/';
  cartApiUrl = 'api/ShoppingCart/';
  promotionApiUrl = 'api/Promotions/';
  total = 0;
  itemList: Products[];
  cartList: ShoppingCart[];
  PromotionList: Promotions[];
  constructor(private http: HttpClient) { }
  shoppingCart: ShoppingCart;
  addProduct(cart: ShoppingCart): Observable<ShoppingCart>{
    return this.http.post<ShoppingCart>(this.myAppUrl + this.cartApiUrl, cart);
  }

  addingItems(item: string){
    
    let quantity = 0;
    var product =  this.itemList.find(e => e.name == item);
    var itemCart = this.cartList.find(e => e.item == item);
    var promotion;
    
    if(itemCart){
      this.shoppingCart.id = product.id;
      this.shoppingCart.item = product.name;
      this.shoppingCart.quantity = 1;
      this.shoppingCart.price = product.price;
      this.shoppingCart.total = product.price;

      this.addProduct(this.shoppingCart);
    }
    else
    {
      quantity = itemCart.quantity + 1;
      this.shoppingCart.id = itemCart.id;
      this.shoppingCart.item = itemCart.item;
      this.shoppingCart.quantity = quantity;
      this.shoppingCart.price = itemCart.price;
      this.shoppingCart.total = (itemCart.quantity + 1) * itemCart.price;

      if(product.promotionId !== null){
        promotion = this.PromotionList.find(e => e.id == product.promotionId);

        if(promotion){
          if(promotion.promotion.startsWith('Buy')){
            if (quantity % 2 == 0)
            {
                let offer = 0;
                for (let i = 0; i < quantity; i++)
                {
                    if(i%2 == 0)
                    {
                        offer++;
                    }
                }
                this.shoppingCart.promotion_Applied = "Buy " + offer + " Get " + offer + " Free";
            }
            else
            {
              if (quantity % 3 == 0)
              {
                this.shoppingCart.promotion_Applied = quantity + " for " + (10 * quantity) + " Euro";
              }
            }
          }
        }
        //Update
      }
    }
  }
  getProducts(){
    this.http.get(this.myAppUrl + this.productApiUrl).toPromise()
                  .then(data => {
                    this.itemList = data as Products[];
                  });
  }

  getCart(){
    this.http.get(this.myAppUrl + this.cartApiUrl).toPromise()
                  .then(data => {
                    this.cartList = data as ShoppingCart[];
                    this.getTotal(data);
                  });
  }

  getTotal(data){
    for(let j=0;j<data.length;j++)
    {   
      this.total+= data[j].total;
    }  
  }

  getPromotion(){
    this.http.get(this.myAppUrl + this.promotionApiUrl).toPromise()
                  .then(data => {
                    this.PromotionList = data as Promotions[];
                  });
  }

  deleteFromCart(id: number): Observable<ShoppingCart> {
    return this.http.delete<ShoppingCart>(this.myAppUrl + this.cartApiUrl + id);
  }

  /*update(id: number, cart : ShoppingCart): Observable<ShoppingCart>{
    //return this.update<ShoppingCart>(this.myAppUrl + this.cartApiUrl + id, this.shoppingCart);
  }*/
}
