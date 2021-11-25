namespace TokenHandler.Entities
{
    public record StoredTokenModel
    {
        public IdObjectModel idObject { get; init; }
        public string refreshToken { get; init; }
        public string accessToken { get; init; }
    }

}