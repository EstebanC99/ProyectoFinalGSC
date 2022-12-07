import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Loan } from 'src/app/Interfaces/loan';
import { LoanService } from 'src/app/Services/Loan/loan.service';

@Component({
  selector: 'app-loans-list',
  templateUrl: './loans-list.component.html',
  styleUrls: ['./loans-list.component.css']
})
export class LoansListComponent implements OnInit {
  loanState: FormControl = new FormControl('');

  dataSource = new MatTableDataSource<Loan>([]);
  displayedColumns: string[] = ['id', 'thing', 'category', 'person', 'loanDate', 'borrowedAmount', 'returnDate'];
  @ViewChild(MatPaginator, {static: true}) paginator!: MatPaginator;
  @Output() selectedLoan = new EventEmitter<Loan>();
  @Output() displayed = new EventEmitter<boolean>();

  constructor(
    private formBuilder: FormBuilder,
    private loanService: LoanService
  ) { 
    this.loanState.valueChanges.subscribe((data: string) => {
      if (data === '') {
        this.loanService.getLoansList();
      }
      
      if (data === 'Opened') {
        this.loanService.getCurrentLoans();
      }

      if (data === 'Closed') {
        this.loanService.getCLosedLoans();
      }
    });
  }

  ngOnInit(): void {
    this.loanService.loansList.subscribe((data: Loan[]) => {
      this.dataSource.data = data;
    });
    this.dataSource.paginator = this.paginator;
  }

  selectLoan(selectedLoan: Loan): void {
    if (selectedLoan === null || selectedLoan === undefined) return;

    this.displayed.emit(false);

    this.selectedLoan.emit(selectedLoan);
  }
}
