using Bank.Application.Service.Interfaces;
using Bank.Domain.Models;
using Bank.Infra.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BankSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User>
    {
        private readonly IUserService appService;

        public UserController(IUserService appService)
        {
            this.appService = appService;
        }


        [HttpPost("AddUser")]
        //[Authorize]
        public async Task<IActionResult> AddUser([FromBody] User item)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.AddUser(item);
                return StatusCode((int)HttpStatusCode.Created, result);

            });
        }

        [HttpGet("ValidationUser")]
        public async Task<IActionResult> ValidationUser(String Document)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.ValidationUser(Document);
                return StatusCode((int)HttpStatusCode.OK, result);

            });
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User item)
        {
            return await TryExecuteAction(async () =>
            {
                appService.UpdateUser(item);
                return StatusCode((int)HttpStatusCode.OK);

            });
        }

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] User item)
        {
            return await TryExecuteAction(async () =>
            {
                appService.DeleteUser(item);
                return StatusCode((int)HttpStatusCode.OK);
            });
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser(int _offset = 1, int _limit = 10)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.GetAllUser(_offset, _limit);
                return StatusCode((int)HttpStatusCode.OK, result);

            });
        }

        //public async Task<IActionResult> GetClientsByFilter(Expression<Func<User, bool>> predicate)
        //{
        //    return await TryExecuteAction(async () =>
        //    {
        //        var result = await appService.GetClientsByFilter(predicate);
        //        return StatusCode((int)HttpStatusCode.OK, result);

        //    });
        //}

        [HttpGet("GetUserByCode")]
        public async Task<IActionResult> GetUserByCode(Guid code)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.GetUserByCode(code);
                return StatusCode((int)HttpStatusCode.OK, result);

            });
        }
    }
}
