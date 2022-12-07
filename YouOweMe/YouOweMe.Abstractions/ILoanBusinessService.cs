using YouOweMe.DataView;

namespace YouOweMe.Abstractions
{
    public interface ILoanBusinessService : IBaseBusinessService
    {
        List<LoanDataView> GetAll();

        LoanDataView GetByID(int id);

        List<LoanDataView> GetCurrentsLoans();

        List<LoanDataView> GetClosedLoans();

        void Register(LoanDataView loanDataView);

        void CloseLoan(LoanDataView loanDataView);
    }
}
