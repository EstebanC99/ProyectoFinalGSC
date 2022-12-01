using YouOweMe.Entities;

namespace YouOweMe.Repositories.Users
{
    public class UserRepository : BaseRepository, IUserRepository
    { 
        public UserRepository(IYouOweMeContext context) : base(context)
        {

        }

        public User GetUserByEmail(string email)
        {
            return this.Context.Users.FirstOrDefault(u => u.Email.Equals(email));
        }
    }
}
