using YouOweMe.Entities;

namespace YouOweMe.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private IYouOweMeContext Context { get; set; }

        public UserRepository(IYouOweMeContext context)
        {
            Context = context;
        }

        public User GetUserByEmail(string email)
        {
            return Context.Users.FirstOrDefault(u => u.Email.Equals(email));
        }
    }
}
