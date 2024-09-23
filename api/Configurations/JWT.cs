namespace api.Configurations
{
    public class JWT
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public long Expiry { get; set; }

    }
}
