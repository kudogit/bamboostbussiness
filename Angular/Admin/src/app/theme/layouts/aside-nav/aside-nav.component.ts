import { Component, OnInit, ViewEncapsulation, AfterViewInit } from '@angular/core';
import { Helpers } from '../../../helpers';

declare let mLayout: any;
@Component({
    selector: "app-aside-nav",
    templateUrl: "./aside-nav.component.html",
    encapsulation: ViewEncapsulation.None,
})
export class AsideNavComponent implements OnInit, AfterViewInit {
    public isSidebarAdmin : boolean = false;
    public buttonColor : string = "danger";
    public title: string = "Is't Admin";
    constructor() {

    }
    ngOnInit() {

    }
    ngAfterViewInit() {

        mLayout.initAside();

    }

    ShowSidebar() : void{
        // console.log("Show Sidebar Admin");
        this.isSidebarAdmin = !this.isSidebarAdmin;
        if(this.isSidebarAdmin){
            this.buttonColor = "primary";
            this.title = "Is Admin";
        }
        else{
            this.buttonColor = "danger";
            this.title = "Is't Admin"
        }
    }

}