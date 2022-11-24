using YouOweMe.Abstractions;
using YouOweMe.DataView;
using YouOweMe.Extensions;
using YouOweMe.Repositories.Users;

namespace YouOweMe.Logic
{
    public class UserLogic : IUserBusinessService
    {
        private IUserRepository Repository { get; set; }

        public UserLogic(IUserRepository repository)
        {
            this.Repository = repository;
        }

        public UserDataView FindUser(string email, string password)
        {
            var user = this.Repository.GetUserByEmail(email);

            if (user is null)
                throw new ValidationException("No existe un usuario registrado con ese Email");

            user.ValidatePassword(password);

            return new UserDataView()
            {
                ID = user.ID,
                Email = user.Email,
                Password = user.Password
            };
        }
    }
}