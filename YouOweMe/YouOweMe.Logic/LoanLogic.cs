using YouOweMe.Abstractions;
using YouOweMe.DataView;
using YouOweMe.Entities.Factories.Interfaces;
using YouOweMe.Entities.Services;
using YouOweMe.Extensions;
using YouOweMe.Repositories.Loans;
using YouOweMe.Repositories.Persons;
using YouOweMe.Repositories.Things;

namespace YouOweMe.Logic
{
    public class LoanLogic : BaseLogic<ILoanRepository>, ILoanBusinessService
    {
        private ILoanFactory Factory { get; set; }

        private IThingDomainService ThingDomainService { get; set; }

        private IThingRepository ThingRepository { get; set; }

        private IPersonRepository PersonRepository { get; set; }

        public LoanLogic(ILoanRepository repository,
                         IHelperMapper mapper,
                         ILoanFactory factory,
                         IThingDomainService thingDomainService,
                         IThingRepository thingRepository,
                         IPersonRepository personRepository)
            : base(repository, mapper)
        {
            this.Factory = factory;
            this.ThingDomainService = thingDomainService;
            this.ThingRepository = thingRepository;
            this.PersonRepository = personRepository;
        }

        public List<LoanDataView> GetAll()
        {
            return this.Repository.GetAll().ConvertAll(l => this.Mapper.LoanToLoanDataView(l));
        }

        public LoanDataView GetByID(int id)
        {
            var loan = this.Repository.GetByID(id);

            if (loan is null)
                throw new ValidationException("No se encontro el Prestamo seleccionado");

            return this.Mapper.LoanToLoanDataView(loan);
        }

        public List<LoanDataView> GetCurrentsLoans()
        {
            return this.Repository.GetCurrentsLoans().ConvertAll(l => this.Mapper.LoanToLoanDataView(l));
        }

        public List<LoanDataView> GetClosedLoans()
        {
            return this.Repository.GetClosedLoans().ConvertAll(l => this.Mapper.LoanToLoanDataView(l));
        }

        public void Register(LoanDataView loanDataView)
        {
            var thing = this.ThingRepository.GetByID(loanDataView.Thing.ID ?? default);

            if (thing is null)
                throw new ValidationException("No se encontro la Cosa elegida");

            var person = this.PersonRepository.GetByID(loanDataView.Person.ID ?? default);

            if (person is null)
                throw new ValidationException("No se encontro la Persona seleccionada");

            var loan = this.Factory.Crear(thing, person, loanDataView.BorrowedAmount, this.ThingDomainService);

            this.Repository.Add(loan);
        }

        public void CloseLoan(LoanDataView loanDataView)
        {
            var loan = this.Repository.GetByID(loanDataView.ID.Value);

            if (loan is null)
                throw new ValidationException("No se encontro el prestamo elegido!");

            loan.Close();

            this.Repository.Save(loan);
        }
    }
}
