import { Injectable } from '@angular/core';
import { FormGroup, Validators, FormControl, FormArray, FormBuilder, FormArrayName } from "@angular/forms";


@Injectable({
  providedIn: 'root'
})
export class TaksModel {
  constructor(private formBuilder: FormBuilder){}

  public Form = new FormGroup({

      name: new FormControl('', [
          Validators.maxLength(50) 
      ]), 
      sname: new FormControl('', [
          Validators.maxLength(50)  
      ]),
      bd: new FormControl(),
      phone: new FormControl('+380', [
        Validators.pattern('^\\+380\\d{3}\\d{2}\\d{2}\\d{2}$')
      ]),
      email: new FormControl('', [ 
        Validators.pattern('^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$') 
      ]),
      Works: new FormArray([this.formBuilder.group({
          Country: '',
          AvrSalery: '',
          Start: '',
          Stop: '',
          OffenThinks: false
      })
      ]),
   
      officilal_ukr_work_any_time: new FormControl(false),
      officilal_eu_work_any_time: new FormControl(false),
      officilal_ukr_work_now: new FormControl(false),
      officilal_eu_work_now: new FormControl(false),
   
      presonal_data_agree: new FormControl(false)
      
  }); 
}
