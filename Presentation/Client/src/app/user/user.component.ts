import { Component, OnInit } from '@angular/core';
import { RegisterService } from './register.service';
import { User } from './user';
import {
  FormGroup,
  FormControl,
  Validators,
  AbstractControl,
} from '@angular/forms';
import { MiniumAgeValidator } from './validators';
import { Governorate } from '../governorate';
import { City } from '../city';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
})
export class UserComponent implements OnInit {
  firstName!: AbstractControl;
  lastName!: AbstractControl;
  birthDate!: AbstractControl;
  middleName!: AbstractControl;
  mobileNumber!: AbstractControl;
  hasAddress!: AbstractControl;
  email!: AbstractControl;
  registrationForm!: FormGroup;
  goverId!: AbstractControl;
  cityId!: AbstractControl;
  street!: AbstractControl;
  buildingNumber!: AbstractControl;
  flatNumber!: AbstractControl;
  governorateList: Governorate[] = [];
  cityList: City[] = [];
  selectedGovernorateId: any;
  users: User[] = [];
  newUser: User = {
    firstName: undefined,
    middleName: undefined,
    lastName: undefined,
    birthDate: undefined,
    mobileNumber: undefined,
    email: undefined,
    hasAddress: false,
    cityId: undefined,
    governorateId: undefined,
    buildingNumber: undefined,
    flatNumber: undefined,
    street: undefined,
  };

  constructor(private service: RegisterService) {}

  ngOnInit(): void {
    this.registrationForm = new FormGroup({
      firstName: new FormControl('', [
        Validators.required,
        Validators.maxLength(20),
      ]),
      middleName: new FormControl('', [Validators.maxLength(40)]),
      lastName: new FormControl('', [
        Validators.required,
        Validators.maxLength(20),
      ]),
      birthDate: new FormControl('', [
        Validators?.required,
        MiniumAgeValidator(20),
      ]),
      email: new FormControl('', [Validators.required, Validators.email]),
      mobileNumber: new FormControl('', [
        Validators?.required,
        Validators.pattern(/^\+20(10|11|12|15)[0-9]{8}$/),
      ]),
      hasAddress: new FormControl(''),
      goverId: new FormControl(),
      cityId: new FormControl(),
      street: new FormControl(''),
      buildingNumber: new FormControl(''),
      flatNumber: new FormControl(''),
    });
    this.setNameFields();
    this.addConditionalValidation();
    this.getGovernorateList();
  }

  setNameFields() {
    this.firstName = this.registrationForm.controls['firstName'];
    this.middleName = this.registrationForm.controls['middleName'];
    this.lastName = this.registrationForm.controls['lastName'];
    this.birthDate = this.registrationForm.controls['birthDate'];
    this.email = this.registrationForm.controls['email'];
    this.mobileNumber = this.registrationForm.controls['mobileNumber'];
    this.hasAddress = this.registrationForm.controls['hasAddress'];
    this.goverId = this.registrationForm.controls['goverId'];
    this.cityId = this.registrationForm.controls['cityId'];
    this.street = this.registrationForm.controls['street'];
    this.buildingNumber = this.registrationForm.controls['buildingNumber'];
    this.flatNumber = this.registrationForm.controls['flatNumber'];
  }

  addConditionalValidation() {
    this.hasAddress.valueChanges.subscribe((value) => {
      if (value) {
        this.goverId.addValidators([Validators.required]);
        this.cityId.addValidators([Validators.required]);
        this.street.addValidators([
          Validators.required,
          Validators.maxLength(200),
        ]);
        this.buildingNumber.addValidators([Validators.required]);
        this.flatNumber.addValidators([Validators.required]);
      } else {
        this.goverId.clearValidators();
        this.cityId.clearValidators();
        this.street.clearValidators();
        this.buildingNumber.clearValidators();
        this.flatNumber.clearValidators();
      }
      this.goverId.updateValueAndValidity();
      this.cityId.updateValueAndValidity();
      this.street.updateValueAndValidity();
      this.buildingNumber.updateValueAndValidity();
      this.flatNumber.updateValueAndValidity();
    });
  }
  getGovernorateList() {
    this.service.getGovernorateList().subscribe({
      next: (e) => (this.governorateList = e),
      error: (e) => {
        console.log(e.error.errors);
      },
    });
  }

  OnGovernorateChange(event: any) {
    this.selectedGovernorateId = event.target.value;
    this.service.getCityList().subscribe({
      next: (e) =>
        (this.cityList = e.filter(
          (e) => e.governorateId == this.selectedGovernorateId
        )),
      error: (e) => {
        console.log(e.error.errors);
      },
    });
  }

  onSubmit() {
    if (this.registrationForm?.valid) {
      this.newUser.firstName = this.firstName.value;
      this.newUser.middleName = this.middleName.value;
      this.newUser.lastName = this.lastName.value;
      this.newUser.birthDate = this.birthDate.value;
      this.newUser.email = this.email.value;
      this.newUser.mobileNumber = this.mobileNumber.value;
      this.newUser.governorateId =
        this.goverId.value === '' ? undefined : +this.goverId.value;
      this.newUser.cityId =
        this.cityId.value === '' ? undefined : +this.cityId.value;
      this.newUser.street = this.street.value;
      this.newUser.buildingNumber = this.buildingNumber.value;
      this.newUser.flatNumber = this.flatNumber.value;

      this.service.postUser(this.newUser).subscribe({
        next: (user) => this.users?.push(user)
      });
    } else {
      console.log('the form is invalid ');
    }
  }
}
