import { Injectable } from '@angular/core';
import { WorkModel } from './work-model.service';
import { FormArray, FormControl, FormBuilder } from '@angular/forms';
@Injectable({
  providedIn: 'root'
})
export class WorkDataService {
  
  constructor(public model: WorkModel,
      private formBuilder: FormBuilder) { }

  
  public addEducations() {// DRY???????
    (this.model.Form.controls['educations'] as FormArray).push( this.formBuilder.group({
      Institution: '',
      Faculty: '',
      Form: '',
      Start: '',
      Stop: '',
  }) );
  }

  public send(){
    console.log(this.model.Form);
  }

}
