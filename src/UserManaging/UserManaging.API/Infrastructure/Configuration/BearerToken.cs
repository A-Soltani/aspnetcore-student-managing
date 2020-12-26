namespace UserManaging.API.Infrastructure.Configuration
{
    public class BearerToken
    {
        public string ServerSecret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int AccessTokenExpirationMinutes { get; set; }
    }
}