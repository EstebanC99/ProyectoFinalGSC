using YouOweMe.Entities;

namespace YouOweMe.Repositories.Users
{
    public interface IUserRepository: IBaseRepository
    {
        User GetUserByEmail(string email);
    }
}