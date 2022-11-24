using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YouOweMe.DataView;
using YouOweMe.WebApi.Security.Configurations;

namespace YouOweMe.WebApi.Security
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtOptions jwtOptions;

        public JwtHandler(IOptions<JwtOptions> options)
        {
            jwtOptions = options?.Value ?? throw new ArgumentException(nameof(options));
        }
        public string GenerateToken(UserDataView user)
        {
            var signingCredentials = GetSigningCredentials();

            var claims = GetClaims(user);

            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(this.jwtOptions.Key);

            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private List<Claim> GetClaims(UserDataView user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.PrimarySid, user.ID.ToString(), typeof(int).ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                claims: claims,
                issuer: this.jwtOptions.Issuer,
                audience: this.jwtOptions.Audience,
                signingCredentials: signingCredentials);

            return tokenOptions;
        }
    }
}

