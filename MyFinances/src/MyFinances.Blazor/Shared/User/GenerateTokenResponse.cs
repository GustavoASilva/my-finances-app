namespace MyFinances.Blazor.Shared.User
{
    public class GenerateTokenResponse
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
    }
}
