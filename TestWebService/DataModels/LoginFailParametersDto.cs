namespace TestWebService.DataModels
{
    public record LoginFailParametersDto
    {
        public string? UserName { get; set; }

        public int? FailCount { get; set; }

        public int? FetchLimit { get; set; }
    }
}
