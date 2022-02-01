using Bank.Domain.Models;
using Bank.Infra.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BankSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankClientController : BaseController<BankClient>
    {
        private readonly IBankClientService appService;

        public BankClientController(IBankClientService appService)
        {
            this.appService = appService;
        }


        [HttpPost("AddClient")]
        //[Authorize]
        public async Task<IActionResult> AddClient([FromBody] BankClient item)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.AddClient(item);
                return StatusCode((int)HttpStatusCode.Created, result);

            });
        }

        [HttpPost("UpdateClient")]
        public async Task<IActionResult> UpdateClient([FromBody] BankClient item)
        {
            return await TryExecuteAction(async () =>
            {
                appService.UpdateClient(item);
                return StatusCode((int)HttpStatusCode.Created);

            });
        }

        [HttpPost("DeleteClient")]
        public async Task<IActionResult> DeleteClient([FromBody] BankClient item)
        {
            return await TryExecuteAction(async () =>
            {
                appService.DeleteClient(item);
                return StatusCode((int)HttpStatusCode.Created);

            });
        }

        [HttpGet("GetAllClients")]
        public async Task<IActionResult> GetAllClients(int _offset = 1, int _limit = 10)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.GetAllClients(_offset, _limit);
                return StatusCode((int)HttpStatusCode.Created, result);

            });
        }

        [HttpGet("GetClientsByCode")]
        public async Task<IActionResult> GetClientsByCode(Guid code)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.GetClientsByCode(code);
                return StatusCode((int)HttpStatusCode.Created, result);

            });
        }

        //public async Task<IActionResult> GetClientsByFilter(Expression<Func<BankClient, bool>> predicate)
        //{
        //    return await TryExecuteAction(async () =>
        //    {
        //        var result = await appService.GetClientsByFilter(predicate);
        //        return StatusCode((int)HttpStatusCode.Created, result);

        //    });
        //}
    }
}
