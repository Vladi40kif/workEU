import { Injectable, OnInit, Inject } from '@angular/core';
import { TaksModel } from './taks-model.service';
import { FormArray, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TaksDataService {

  _baseUrl: string;

  constructor(public model: TaksModel,
    private formBuilder: FormBuilder,
    private httpClient: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  public addWorks() {// DRY???????
    (this.model.Form.controls['Works'] as FormArray).push(this.formBuilder.group({
      Country: '',
      AvrSalery: '',
      Start: '',
      Stop: '',
      OffenThinks: false
    }));

  }

  public send() {
    return this.httpClient.post(this._baseUrl + 'api/Email/taks', this.model.Form.value);
  }
  public rm(ind) {
    (this.model.Form.controls['Works'] as FormArray).removeAt(ind);
  }
}
