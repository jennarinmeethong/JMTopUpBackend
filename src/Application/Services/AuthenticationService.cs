namespace JMTopUpBackend.Application.Services
{
    public interface IAuthenticationService
    {
        string BuildToken(UserProfile userProfile);
    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string BuildToken(UserProfile userProfile)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>();
            claims.Add(new Claim("Id", userProfile.Id.ToString()));
            claims.Add(new Claim("Username", userProfile.UserName));
            claims.Add(new Claim("Email", userProfile.Email));
            claims.Add(new Claim("Role", userProfile.Role.Name));
            var jwtSecurityToken = new JwtSecurityToken(configuration["JWT:ValidIssuer"], configuration["JWT:ValidAudience"], claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);
        }
    }
}