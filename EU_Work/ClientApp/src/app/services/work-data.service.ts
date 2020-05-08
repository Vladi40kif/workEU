import { Injectable, OnInit, Inject } from '@angular/core';
import { WorkModel } from './work-model.service';
import { FormArray, FormControl, FormBuilder } from '@angular/forms';
import { HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class WorkDataService implements OnInit {
  
  _baseUrl: string;
  
  constructor(public model: WorkModel,
      private formBuilder: FormBuilder,
      private httpClient: HttpClient,
      @Inject('BASE_URL') baseUrl: string) {
          this._baseUrl = baseUrl;
       }
  
  ngOnInit(){}

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
    return this.httpClient.post(this._baseUrl + 'api/Email/work',this.model .Form.value);
  }
  public rm(ind){
    (this.model.Form.controls['educations'] as FormArray).removeAt(ind);
  }

}
