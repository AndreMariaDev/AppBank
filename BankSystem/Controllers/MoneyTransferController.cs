using Bank.Domain.Models;
using Bank.Infra.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BankSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyTransferController : BaseController<MoneyTransfer>
    {
        private readonly IMoneyTransferService appService;

        public MoneyTransferController(IMoneyTransferService appService)
        {
            this.appService = appService;
        }


        [HttpPost("AddMoneyTransfer")]
        //[Authorize]
        public async Task<IActionResult> AddMoneyTransfer([FromBody] MoneyTransfer item)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.AddMoneyTransfer(item);
                return StatusCode((int)HttpStatusCode.Created, result);

            });
        }

        [HttpPost("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus([FromBody] MoneyTransfer item)
        {
            return await TryExecuteAction(async () =>
            {
                appService.UpdateStatus(item);
                return StatusCode((int)HttpStatusCode.OK);
            });
        }

        [HttpPost("CancelMoneyTransfer")]
        public async Task<IActionResult> CancelMoneyTransfer([FromBody] MoneyTransfer item)
        {
            return await TryExecuteAction(async () =>
            {
                appService.CancelMoneyTransfer(item);
                return StatusCode((int)HttpStatusCode.OK);

            });
        }

        [HttpGet("GetAllMoneyTransfer")]
        public async Task<IActionResult> GetAllMoneyTransfer(int _offset = 1, int _limit = 10)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.GetAllMoneyTransfer(_offset, _limit);
                return StatusCode((int)HttpStatusCode.Created, result);

            });
        }

        [HttpGet("GetMoneyTransferByCode")]
        public async Task<IActionResult> GetMoneyTransferByCode(Guid code)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.GetMoneyTransferByCode(code);
                return StatusCode((int)HttpStatusCode.Created, result);

            });
        }

        //public async Task<IActionResult> GetMoneyTransferByFilter(Expression<Func<MoneyTransfer, bool>> predicate)
        //{
        //    return await TryExecuteAction(async () =>
        //    {
        //        var result = await appService.AddCredential(item);
        //        return StatusCode((int)HttpStatusCode.Created, result);

        //    });
        //    return await _moneyTransferService.GetMoneyTransferByFilter(predicate);
        //}
    }
}
