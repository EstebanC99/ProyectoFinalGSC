using Microsoft.EntityFrameworkCore;
using YouOweMe.Entities;

namespace YouOweMe.Repositories.Loans
{
    public class LoanRepository : BaseRepository, ILoanRepository
    {
        public LoanRepository(IYouOweMeContext context) : base(context)
        {

        }

        public List<Loan> GetAll()
        {
            return this.Context.Loans
                       .Include(l => l.Thing)
                       .Include(l => l.Person)
                       .Include(l => l.Thing != null ? l.Thing.Category : null)
                       .OrderBy(l => l.LoanDate)
                       .ToList();
        }

        public Loan? GetByID(int id)
        {
            return this.Context.Loans.Where(l => l.ID == id)
                       .Include(l => l.Thing)
                       .Include(l => l.Person)
                       .Include(l => l.Thing != null ? l.Thing.Category : null)
                       .FirstOrDefault();
        }

        public List<Loan> GetCurrentsLoans()
        {
            return this.Context.Loans
                       .Include(l => l.Thing)
                       .Include(l => l.Person)
                       .Include(l => l.Thing != null ? l.Thing.Category : null)
                       .Where(l => !l.ReturnDate.HasValue)
                       .OrderBy(l => l.LoanDate)
                       .ToList();
        }

        public List<Loan> GetClosedLoans()
        {
            return this.Context.Loans
                       .Include(l => l.Thing)
                       .Include(l => l.Person)
                       .Include(l => l.Thing != null ? l.Thing.Category : null)
                       .Where(l => l.ReturnDate.HasValue)
                       .OrderBy(l => l.LoanDate)
                       .ToList();
        }

        public void Add(Loan loan)
        {
            this.Context.Loans.Add(loan);

            this.Context.SaveChanges();
        }

        public void Delete(Loan loan)
        {
            this.Context.Loans.Remove(loan);

            this.Context.SaveChanges();
        }

        public void Save(Loan loan)
        {
            this.Context.Loans.Update(loan);

            this.Context.SaveChanges();
        }
    }
}
