import { Component, OnInit, ViewChild } from '@angular/core';
import { Loan } from 'src/app/Interfaces/loan';
import { LoanDetailComponent } from '../loan-detail/loan-detail.component';
import { LoansListComponent } from '../loans-list/loans-list.component';

@Component({
  selector: 'app-loan-menu',
  templateUrl: './loan-menu.component.html',
  styleUrls: ['./loan-menu.component.css']
})
export class LoanMenuComponent implements OnInit {

  displayLoanDetail: boolean = false;
  displayLoanList: boolean = true;
  @ViewChild(LoanDetailComponent) loanDetail!: LoanDetailComponent;
  @ViewChild(LoansListComponent) loanList!: LoansListComponent;

  constructor() { }

  ngOnInit(): void {
  }

  displayLoan(selectedLoan: Loan): void {
    this.loanDetail.displayLoan(selectedLoan);
  }
}
