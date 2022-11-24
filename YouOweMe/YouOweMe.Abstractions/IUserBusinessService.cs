using YouOweMe.DataView;

namespace YouOweMe.Abstractions
{
    public interface IUserBusinessService
    {
        UserDataView FindUser(string email, string password);
    }
}