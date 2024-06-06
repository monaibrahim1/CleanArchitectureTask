import { AbstractControl, ValidatorFn } from '@angular/forms';

export function MiniumAgeValidator(minAge: number): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    // Convert the date of birth from a string to a Date object
    let birthDate = new Date(control.value);
    let today = new Date();

    // Calculate the age
    let age = today.getFullYear() - birthDate.getFullYear();

    // Check if the birthday has occurred yet this year
    let monthDifference = today.getMonth() - birthDate.getMonth();
    let dayDifference = today.getDate() - birthDate.getDate();

    // If birth month is later in the year, or it's the birth month but the birthday hasn't occurred yet
    if (monthDifference < 0 || (monthDifference === 0 && dayDifference < 0)) {
      age--;
    }

    // Return true if age is 20 or older, otherwise false
    return age >= minAge ? null : { minimumAge: { value: minAge } };
  };
}
