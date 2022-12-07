import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Loan } from 'src/app/Interfaces/loan';
import { LoanService } from 'src/app/Services/Loan/loan.service';

@Component({
  selector: 'app-loan-detail',
  templateUrl: './loan-detail.component.html',
  styleUrls: ['./loan-detail.component.css']
})
export class LoanDetailComponent implements OnInit {

  selectedLoan?: Loan;
  @Output() displayed = new EventEmitter<boolean>();

  constructor(private loanService: LoanService) { }

  ngOnInit(): void {
  }

  displayLoan(selectedLoan: Loan): void {
    this.selectedLoan = selectedLoan;

    this.displayed.emit(true);
  }

  setAsClosed(): void {
    if (this.selectedLoan === undefined) return;

    this.loanService.setAsClosed(this.selectedLoan);

    this.cancel();
  }

  cancel(): void {
    this.selectedLoan = undefined;

    this.displayed.emit(false);
  }
}
