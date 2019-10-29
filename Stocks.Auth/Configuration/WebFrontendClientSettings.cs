namespace Stocks.Auth.Domain.Configuration
{
    public class WebFrontendClientSettings
    {
        public string Secret { get; set; }
        public string[] RedirectUris { get; set; }
        public int AccessTokenLifetime { get; set; }
    }
}
