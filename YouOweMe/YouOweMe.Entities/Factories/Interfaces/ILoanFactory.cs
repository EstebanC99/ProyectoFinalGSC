using YouOweMe.Entities.Services;

namespace YouOweMe.Entities.Factories.Interfaces
{
    public interface ILoanFactory
    {
        Loan Crear(Thing thing, Person person, int borrowedAmount, IThingDomainService thingDomainService);
    }
}