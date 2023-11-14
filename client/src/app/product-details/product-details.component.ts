import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import products from '../products';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css'],
})
export class ProductDetailsComponent implements OnInit {
  product: any;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      const productId = params['id'];
      this.product = products.find((p) => p._id === productId);
    });
  }
}
