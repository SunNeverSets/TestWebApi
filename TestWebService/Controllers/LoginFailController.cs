using Microsoft.AspNetCore.Mvc;
using TestWebService.Database;
using TestWebService.DataModels;

namespace TestWebService.Controllers
{
    [ApiController]
    [Route("api")]
    public class LoginFailController : ControllerBase
    {
        private readonly ILogger<LoginFailController> _logger;
        private readonly MyDbContext _dbContext;

        public LoginFailController(ILogger<LoginFailController> logger)
        {
            _logger = logger;
            //_dbContext = dbContext;
        }

        [HttpGet("loginfailtotal")]
        public IActionResult GetLoginFailTotal([FromQuery] LoginFailParametersDto loginFailParameters)
        {
            var query = TestData.LoginFailures.LoginFailuresData;

            // Apply filtering based on parameters
            if (!string.IsNullOrEmpty(loginFailParameters.UserName))
                query = query.Where(x => x.UserName == loginFailParameters.UserName).ToList();

            if (loginFailParameters.FailCount.HasValue)
                query = query.Where(x => x.FailureCount == loginFailParameters.FailCount.Value).ToList();

            // Apply fetch_limit if set
            if (loginFailParameters.FetchLimit.HasValue)
                query = query.Take(loginFailParameters.FetchLimit.Value).ToList();

            return Ok(query.ToList());
        }

        [HttpPut("resetloginfailtotal")]
        public IActionResult ResetLoginFailTotal([FromQuery] ResetLoginFailParametersDto request)
        {
            if (request == null || string.IsNullOrEmpty(request.UserName))
            {
                return BadRequest("Username parameter is required.");
            }

            var loginFailure = TestData.LoginFailures.LoginFailuresData.FirstOrDefault(x => x.UserName == request.UserName);

            if (loginFailure != null)
            {
                loginFailure.FailureCount = 0;
                //_dbContext.SaveChanges();
                return Ok($"Login failures for {request.UserName} have been reset.");
            }

            return NotFound($"User {request.UserName} not found in login failures.");
        }
    }
}