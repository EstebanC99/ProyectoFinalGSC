namespace YouOweMe.Entities.Services
{
    public interface IThingDomainService
    {
        int? GetBorrowedAmount(Thing thing);
    }
}
