using YouOweMe.Entities;

namespace YouOweMe.Repositories.Users
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
    }
}