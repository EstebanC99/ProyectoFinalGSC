using YouOweMe.Entities;

namespace YouOweMe.Repositories.Loans
{
    public interface ILoanRepository : IBaseRepository
    {
        List<Loan> GetAll();

        Loan? GetByID(int id);

        List<Loan> GetCurrentsLoans();

        List<Loan> GetClosedLoans();

        void Add(Loan loan);

        void Delete(Loan loan);

        void Save(Loan loan);
    }
}