using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TravelCompany.data
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> userManager;
        private readonly IOptions<JWT> jwt;
        public AuthService(UserManager<User> userManager, IOptions<JWT> jwt)
        {
            this.userManager = userManager;
            this.jwt = jwt;
        }
        public async Task<ActionResult<AuthModel>> Register(VMUser login)
        {
            if (login.username == null || login.password == null) { return new AuthModel { Message = "username or password is null" }; }
            var u = await userManager.FindByNameAsync(login.username);
            if (u is not null) { return new AuthModel { Message = "the phone number is uses" }; }
            var user = new User
            {
                UserName = login.username,
                PhoneNumber = login.username
            };
            var res = await userManager.CreateAsync(user, login.password);
            if (!res.Succeeded) { return new AuthModel { Message = "Error in Create User" }; }
            await userManager.AddToRoleAsync(user, "User");
            var token = await CreateJwtSecurityToken(user);
            var back = new AuthModel
            {
                Message = "Every thing is ok",
                IsAuthanticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expireson = token.ValidTo.ToLocalTime(),
                Roles = await userManager.GetRolesAsync(user),
                Username = login.username,
            };
            return back;
        }

        private async Task<JwtSecurityToken> CreateJwtSecurityToken(User identityUser)
        {
            var userClaims = await userManager.GetClaimsAsync(identityUser);
            var roles = await userManager.GetRolesAsync(identityUser);
            var roleClaims = new List<Claim>();
            foreach (var role in roles)
            {
                roleClaims.Add(new Claim("roles", role));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,identityUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim("uid",identityUser.Id)
            }.Union(userClaims).Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Value.Key!));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwt.Value.Issuer,
                audience: jwt.Value.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(jwt.Value.DurationInDays).ToLocalTime(),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

    }
}
