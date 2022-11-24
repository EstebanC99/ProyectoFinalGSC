using YouOweMe.DataView;

namespace YouOweMe.WebApi.Security
{
    public interface IJwtHandler
    {
        string GenerateToken(UserDataView user);
    }
}