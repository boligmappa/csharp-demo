namespace TokenHandler.Entities
{
    public record TokenResponseModel
    {
        public string refresh_token { get; init; }
        public string access_token { get; init; }
    }

}