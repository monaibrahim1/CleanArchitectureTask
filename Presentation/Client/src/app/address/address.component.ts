import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../user/register.service';
import { Governorate } from '../governorate';
import { City } from '../city';
import {
  FormGroup,
  FormControl,
  Validators,
  AbstractControl,
} from '@angular/forms';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
})
export class AddressComponent implements OnInit {
  governorateList: Governorate[] = [];
  cityList: City[] = [];
  selectedGovernorateId:any;
  addressForm!:FormGroup ;
  goverId!:AbstractControl;
  cityId!:AbstractControl;
  street!:AbstractControl;
  buildingNumber!:AbstractControl;
  flatNumber!:AbstractControl;
  

 

  constructor(private service: RegisterService) {}
  ngOnInit(): void {
    this.addressForm=new FormGroup({
      goverId:new FormControl('',Validators.required),
      cityId:new FormControl('',Validators.required),
      street:new FormControl('',[Validators.required,Validators.maxLength(200)]),
      buildingNumber:new FormControl('',Validators.required),
      flatNumber:new FormControl('',Validators.required),
     
      
    })
   this.goverId= this.addressForm.controls['goverId'];
   this.cityId= this.addressForm.controls['cityId'];
   this.street= this.addressForm.controls['street'];
   this.buildingNumber= this.addressForm.controls['buildingNumber'];
   this.flatNumber= this.addressForm.controls['flatNumber'];

    this.service.getGovernorateList().subscribe({
      next: (e) => (this.governorateList = e),
      error: (e) => {
        console.log(e.error.errors);
      },
    });

   
  }

  OnGovernorateChange(event:any){
  this.selectedGovernorateId=  event.target.value;
    this.service.getCityList().subscribe({
      next: (e) => (this.cityList = e.filter((e)=>e.governorateId==this.selectedGovernorateId)),
      error: (e) => {
        console.log(e.error.errors);
      },
    });
  }
}
