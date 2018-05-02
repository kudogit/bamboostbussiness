import { Component, OnInit, ViewEncapsulation , AfterViewInit } from '@angular/core';
import { ScriptLoaderService } from '../../../../../_services/script-loader.service';

@Component({
    selector: "app-list-product",
    templateUrl: "./list-product.component.html",
    encapsulation: ViewEncapsulation.None,
})
export class ListProductComponent implements OnInit,  AfterViewInit {
    public isAdmin : boolean = false;
    constructor(private _script: ScriptLoaderService) {
    }

    ngOnInit() {
    }

    ngAfterViewInit() {
        this._script.loadScripts('app-list-product',
            ['assets/demo/default/custom/components/datatables/base/data-local.js']);    

    }
}