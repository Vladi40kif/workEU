import { Component, OnInit } from '@angular/core';
import { WorkDataService } from '../services/work-data.service';
import { ToastrService } from 'ngx-toastr';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
@Component({
  selector: 'app-work',
  templateUrl: './work.component.html',
  styleUrls: ['./work.component.css']
})
export class WorkComponent implements OnInit {
  formBuilder: any;

  constructor(public service: WorkDataService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    
  }

  public Submit(){
    this.toastr.info("Не обновляйте сторінку","Відправлення...");
    this.service.send().subscribe(x=>{
      this.toastr.success("Ваша заявка успішно надіслана","Успіх!");  
      this.service.model.Form.reset();
      this.service.model.Form = new FormGroup({

        name: new FormControl('', [
            Validators.maxLength(50) 
        ]), 
        sname: new FormControl('', [
            Validators.maxLength(50)  
        ]),
        bd: new FormControl(),
        educations: new FormArray([this.formBuilder.group({
            Institution: '',
            Faculty: '',
            Form: '',
            Start: '',
            Stop: '',
        })
        ]),
        addres_official: new FormControl(''),
        phone: new FormControl('+380', [
            Validators.pattern('^\\+380\\d{3}\\d{2}\\d{2}\\d{2}$')
        ]),
        email: new FormControl('', [ 
            Validators.pattern('^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$') 
        ]),
        officilal_ukr_work_any_time: new FormControl(false),
        officilal_eu_work_any_time: new FormControl(false),
        officilal_ukr_work_now: new FormControl(false),
        officilal_eu_work_now: new FormControl(false),
        about: new FormControl(''),
        presonal_data_agree: new FormControl(false)
        
    });
    },err=>{
      console.log(err);
      this.toastr.error("Нажаль ваша форма не була надіслана. Обновіть сторінку та спробуйте ще раз.","Помилка!");  
    });
  }

}
