import { Component, OnInit, ViewEncapsulation , AfterViewInit } from '@angular/core';
import { ScriptLoaderService } from '../../../../../_services/script-loader.service';
import { SelectItem, Message } from 'primeng/primeng';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { flatten } from '@angular/compiler';
@Component({
    selector: "app-add-product",
    templateUrl: "./add-product.component.html",
    styleUrls: [
        '../../../../../../../node_modules/primeng/resources/primeng.css',
        '../../../../../../../node_modules/primeng/resources/themes/bootstrap/theme.css',
        './style.css'
    ],
    encapsulation: ViewEncapsulation.None
})
export class NewProductComponent implements OnInit , AfterViewInit {
    public categories : SelectItem[];
    public selectedCategories: string = '';
    public productForm: FormGroup;
    constructor(private _script: ScriptLoaderService) {

    }

   ngOnInit() {
       this.createForm();
       this.categories = [
           {value:0 , label:'Tùy Chọn'},
           {value:1 , label:'Điện Thoại'},
           {value:2 , label:'Máy Tính Bảng'},
           {value:3 , label:'Phụ Kiện'},
       ]
    }

    ngAfterViewInit() {
       
    }

    msgs: Message[];
    
    uploadedFiles: any[] = [];

    onUpload(event) {
        for(let file of event.files) {
            this.uploadedFiles.push(file);
        }
    
        this.msgs = [];
        this.msgs.push({severity: 'info', summary: 'File Uploaded', detail: ''});
    }

    private checkValid() : boolean{
      if(this.productForm.get('categoryId').status == "VALID" 
        && !this.productForm.get('categoryId').pristine){
          return true;
      }
      return false;
    }

    private createForm() {
        this.productForm = new FormGroup({
          // tslint:disable-next-line
          categoryId: new FormControl('', Validators.required),
          name: new FormControl('', Validators.required),
          price: new FormControl('', Validators.required),
          gst: new FormControl('', Validators.required),
          productCode: new FormControl('', Validators.required),
        });
    }
    public save() {
        console.log(this.productForm.value);
    }
}