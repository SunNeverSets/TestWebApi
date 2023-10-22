namespace TestWebService.DataModels
{
    public class LoginFailRecordsDto
    {
        public IReadOnlyCollection<LoginFailRecordDto> Records { get; set; }
    }

    public class LoginFailRecordDto
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public int FailCount { get; set; }
    }
}
