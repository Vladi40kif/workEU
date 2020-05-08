import { Component, OnInit } from '@angular/core';
import { TaksDataService } from '../services/taks-data.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-taks',
  templateUrl: './taks.component.html',
  styleUrls: ['./taks.component.css']
})
export class TaksComponent implements OnInit {

  constructor(public service: TaksDataService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    
  }

  public Submit(){
    //console.log(this.service.model.Form.value);
    this.toastr.info("Не обновляйте сторінку","Відправлення...");
    this.service.send().subscribe(x=>{
      this.toastr.success("Ваша заявка успішно надіслана","Успіх!");  
      this.service.model.Form.reset();
    },err=>{
      console.log(err);
      this.toastr.error("Нажаль ваша форма не була надіслана. Обновіть сторінку та спробуйте ще раз.","Помилка!");  
    });
  }
}
