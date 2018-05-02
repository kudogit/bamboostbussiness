import { Component, OnInit, ViewEncapsulation , AfterViewInit } from '@angular/core';
import { ScriptLoaderService } from '../../../../_services/script-loader.service';

@Component({
    selector: ".m-grid__item.m-grid__item--fluid.m-wrapper",
    templateUrl: "./product.component.html",
    encapsulation: ViewEncapsulation.None,
})
export class ProductComponent implements OnInit {
    constructor() {
    }

    ngOnInit() {
    }
}