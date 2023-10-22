namespace TestWebService.Integration.Tests.ApiFacade
{
    public static class Extensions
    {
        public static ApiResponse ReadResponse(this Task<HttpResponseMessage> responseTask, int timeoutMs = 100000)
        {
            if (responseTask.Wait(timeoutMs))
                return new ApiResponse(responseTask.Result);

            throw new TimeoutException($"Request timed out. Timeout = {timeoutMs}ms");
        }
    }
}
