import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule , ReactiveFormsModule } from '@angular/forms';
import { ProductComponent } from './product.component';
import { DefaultComponent } from '../default.component';
import { LayoutModule } from '../../../layouts/layout.module';
import { NewProductComponent } from './add/add-product.component';
import { ListProductComponent } from './list/list-product.component';
import { 
    AccordionModule,
    ButtonModule,
    CheckboxModule,
    ChipsModule,
    CodeHighlighterModule,
    ColorPickerModule,
    InputMaskModule,
    FieldsetModule,
    GrowlModule,
    InputTextModule,
    MultiSelectModule,
    PanelModule,
    RadioButtonModule,
    SelectButtonModule,
    SplitButtonModule,
    TabViewModule,
    DialogModule,
    DropdownModule,
    FileUploadModule
 } from 'primeng/primeng';

const routes: Routes = [
    {
        path: "",
        component: DefaultComponent,
        children: [
            {
                path: "",
                component: ProductComponent,
                children: [
                    { path: 'add', component: NewProductComponent },
                    { path: 'list', component: ListProductComponent },
                ]
            }
        ]
    }
];

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forChild(routes),
        LayoutModule,
        //primeng Modules
        DropdownModule,
        FileUploadModule
    ],
    declarations: [
        ProductComponent,
        ListProductComponent,
        NewProductComponent
    ]
})

export class ProductModule {

}