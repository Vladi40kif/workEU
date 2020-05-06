import { Injectable, OnInit } from '@angular/core';
import { WorkModel } from './work-model.service';
import { FormArray, FormControl, FormBuilder } from '@angular/forms';
@Injectable({
  providedIn: 'root'
})
export class WorkDataService implements OnInit {
  
  constructor(public model: WorkModel,
      private formBuilder: FormBuilder) { }
  
  ngOnInit(){}

  public addEducations() {// DRY???????
    (this.model.Form.controls['educations'] as FormArray).push( this.formBuilder.group({
      Institution: '',
      Faculty: '',
      Form: '',
      Start: '',
      Stop: '',
  }) );

  console.log(this.model.Form.controls['educations']['controls']);

  }

  public send(){
    console.log(this.model.Form);
  }
  public rm(ind){
    (this.model.Form.controls['educations'] as FormArray).removeAt(ind);
  }

}
