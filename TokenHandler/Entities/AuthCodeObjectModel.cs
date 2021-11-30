namespace TokenHandler.Entities
{
    public record AuthCodeObjectModel
    {
        public IdObjectModel idObject { get; init; }
        public string authCode { get; init; }
        public string codeVerifier { get; init; }
        public string scope { get; init; }
        public string redirectUrl { get; init; }
    }

}