namespace TokenHandler.Entities
{
    public record StoredTokenObject
    {
        public IdObject idObject { get; init; }
        public string refreshToken { get; init; }
        public string accessToken { get; init; }
    }

}