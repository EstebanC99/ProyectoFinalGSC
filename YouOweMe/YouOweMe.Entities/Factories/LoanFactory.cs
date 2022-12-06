using YouOweMe.Entities.Factories.Interfaces;
using YouOweMe.Entities.Services;
using YouOweMe.Extensions;

namespace YouOweMe.Entities.Factories
{
    public class LoanFactory : ILoanFactory
    {
        public Loan Crear(Thing thing,
                          Person person,
                          int borrowedAmount,
                          IThingDomainService thingDomainService)
        {
            var registerAmount = thingDomainService.GetBorrowedAmount(thing);

            if (registerAmount.HasValue && (thing?.Quantity - registerAmount.Value) < borrowedAmount)
                throw new ValidationException("La cantidad a prestar supera la cantidad disponible");

            return new Loan(thing, person, borrowedAmount);
        }
    }
}
