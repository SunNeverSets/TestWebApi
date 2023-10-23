
using TestWebService.DataModels;

namespace TestWebService.Integration.Tests.ApiFacade.Endpoints
{
    public class FailedLoginHistoryClient : WebApi
    {
        public static ApiResponse GetLoginFailTotal(LoginFailParametersDto parameters)
        {
            string url = $"api/loginfailtotal?{ObjToQueryString(parameters)}";

            var apiResponse = Send(HttpMethod.Get, url);

            return apiResponse;
        }

        public static ApiResponse ResetLoginFailTotal(ResetLoginFailParametersDto parameters)
        {
            string url = $"api/resetloginfailtotal?{ObjToQueryString(parameters)}";

            var apiResponse = Send(HttpMethod.Put, url);

            return apiResponse;
        }
    }
}
