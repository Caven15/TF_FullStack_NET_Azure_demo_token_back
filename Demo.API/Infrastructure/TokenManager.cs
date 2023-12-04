
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Demo.API.Infrastructure
{
    public class TokenManager
    {
        internal static string secret = "MIHcAgEBBEIBOxiujaX9dznAhfgnnPZEbM9y1JQl9kCuxh74iGqk9CsgKiR15Txb\r\nwWImW3V/J7G9ggNx/PTHBrzpdRAbdZnpjCSgBwYFK4EEACOhgYkDgYYABACjTc6J\r\nseaqh3penX2xPRbTTz/0nzj1LkwVdG4JcZKLmLVi05MxbIKngOexLux1hj1PEQEl\r\nfQ/UW0BlQuCHm9n3nAE6b1GP8rql+mzV0JtE5pNUMO6wmCvjy+ZdXcYl2v+ytfyw\r\nn9TQP/raGzucfkcFgJflkK4ZtalawfPk6hzXPlqZgA==";
        public static string myIssuer = "monSiteApi.com";
        public static string myAudience = "monSite.com";


        public string GenerateJwt(dynamic user, int expriationsDate = 1)
        {
            // Création des crédentials
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            // Heure actuelle
            DateTime now = DateTime.Now;

            // Création de l'objet contenant les informations à stocker dans le token
            Claim[] myClaims = new[]
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, $"{user.Nom} {user.Prenom}"),
                new Claim(ClaimTypes.Expiration, now.Add(TimeSpan.FromDays(expriationsDate)).ToString(), ClaimValueTypes.DateTime)
            };

            // Génération du token => Nuget : System.IdentityModel.Tokens.jwt
            JwtSecurityToken token = new JwtSecurityToken(
                 claims: myClaims,
                 expires: now.Add(TimeSpan.FromDays(expriationsDate)),
                 signingCredentials: credentials,
                 issuer: myIssuer,
                 audience: myAudience
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
