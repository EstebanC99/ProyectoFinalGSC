using YouOweMe.DataView;

namespace YouOweMe.Abstractions
{
    public interface IUserBusinessService: IBaseBusinessService
    {
        UserDataView FindUser(string email, string password);
    }
}