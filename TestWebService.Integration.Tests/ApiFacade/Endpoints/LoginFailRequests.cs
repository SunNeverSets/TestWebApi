
using TestWebService.DataModels;

namespace TestWebService.Integration.Tests.ApiFacade.Endpoints
{
    public class LoginFailRequests : WebApi
    {
        public static ApiResponse GetLoginFailRecords(LoginFailParametersDto parameters)
        {
            string url = $"session/loginfailtotal?{ObjToQueryString(parameters)}";

            var apiResponse = Send(HttpMethod.Get, url);

            return apiResponse;
        }

        public static ApiResponse PutLoginFailRecord(ResetLoginFailParametersDto parameters)
        {
            string url = $"session/resetloginfailtotal?{ObjToQueryString(parameters)}";

            var apiResponse = Send(HttpMethod.Put, url);

            return apiResponse;
        }
    }
}
