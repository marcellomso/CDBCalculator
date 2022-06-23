import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http'
import { CurrencyPipe } from '@angular/common';

import { CalcService } from '../service/calc-service.service';
import { ReturnData } from '../model/return-data';
import { SendData } from '../model/send-data';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})

export class CalculatorComponent implements OnInit {
  form!: FormGroup;
  public get fc(): any { return this.form.controls; }
  initialValue = 'R$0,01';
  initialDeadline = '2';
  http: HttpClient;
  baseUrl: string;
  return: ReturnData;
  hasError: boolean = false;
  isLoading: boolean = false;

  constructor(
    private fb: FormBuilder, 
    http: HttpClient,
     @Inject('BASE_URL') baseUrl: string, 
     private service: CalcService,
     private currencyPipe: CurrencyPipe) { 
    this.http = http;
    this.baseUrl = baseUrl;
    this.return = this.clearCalc();
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      value: [this.initialValue, [Validators.required, Validators.min(0.01), Validators.max(999_999_999_999.99)]],
      deadline: [this.initialDeadline, [Validators.required, Validators.min(2), Validators.max(180)]]
    });

    this.form.valueChanges.subscribe(f => {
      if (f.value) {
        const newValue = parseFloat(this.getOnlyNumbers(f.value)) / 100.0;
        this.form.patchValue({
          value: this.currencyPipe.transform(newValue, 'BRL', 'symbol', '1.2-2')
        }, { emitEvent: false });
      }
      if (f.deadline) {
        this.form.patchValue({
          deadline: this.getOnlyNumbers(f.deadline)
        }, { emitEvent: false });
      }
    });
  }

  public validator(field: FormControl): any {
    return { 'is-invalid': field.errors && field.touched };
  }

  private getOnlyNumbers(value: string): string {
    return value.replace(/\D/g, '').replace(/^0+/, '') || '0';
  }

  public calcInvestment(): void {
    this.isLoading = true;

    const data = {
      investimentValue: parseFloat(this.getOnlyNumbers(this.form.value.value)) / 100.0,
      deadlineRedemption: +this.form.value.deadline
    } as SendData;
    
    this.return = this.clearCalc();

    this. service.calcInvestment(data).subscribe({
      next: (response: ReturnData) => {
        this.hasError = false;
        this.return = { ...response };
      },
      error: (error: Error) => {
        this.hasError = true;
        console.error(JSON.stringify(error));
      },
    }).add(() => this.isLoading = false);
  }

  public clearForm() : void {
    this.form.reset();
    this.form.patchValue({
      value: this.initialValue,
      deadline: this.initialDeadline
    });
    
    this.return = this.clearCalc();
    this.hasError = false;
  }

  private clearCalc(): ReturnData {
    return {
      grossValue : 0,
      netValue: 0
    } as ReturnData;
  }
}
