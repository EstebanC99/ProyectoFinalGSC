using YouOweMe.DataView;

namespace YouOweMe.Abstractions
{
    public interface ILoanBusinessService : IBaseBusinessService
    {
        List<LoanDataView> GetAll();
        
        LoanDataView GetByID(int id);

        void Register(LoanDataView loanDataView);
    }
}
