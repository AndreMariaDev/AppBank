using Bank.Domain.Models;
using Bank.Infra.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BankSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCredentialsController : BaseController<UserCredentials>
    {
        private readonly IUserCredentialsService appService;

        public UserCredentialsController(IUserCredentialsService appService)
        {
            this.appService = appService;
        }


        [HttpPost("AddCredential")]
        //[Authorize]
        public async Task<IActionResult> AddCredential([FromBody] UserCredentials item)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.AddCredential(item);
                return StatusCode((int)HttpStatusCode.Created, result);

            });
        }

        [HttpGet("ValidationUserCredential")]
        public async Task<IActionResult> ValidationUserCredential(String Login, String Password)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.ValidationUserCredential(Login, Password);
                return StatusCode((int)HttpStatusCode.OK, result);

            });
        }

        [HttpPost("UpdateCredential")]
        public async Task<IActionResult> UpdateCredential([FromBody] UserCredentials item)
        {
            return await TryExecuteAction(async () =>
            {
                appService.UpdateCredential(item);
                return StatusCode((int)HttpStatusCode.OK);

            });
        }

        [HttpPost("DeleteCredential")]
        public async Task<IActionResult> DeleteCredential([FromBody] UserCredentials item)
        {
            return await TryExecuteAction(async () =>
            {
                appService.DeleteCredential(item);
                return StatusCode((int)HttpStatusCode.OK);

            });
        }
    }
}
