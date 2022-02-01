using Bank.Domain.Models;
using Bank.Infra.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BankSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankTransactionController : BaseController<BankTransaction>
    {
        private readonly IBankTransactionService appService;

        public BankTransactionController(IBankTransactionService appService)
        {
            this.appService = appService;
        }


        [HttpPost("AddBankTransaction")]
        //[Authorize]
        public async Task<IActionResult> AddBankTransaction([FromBody] BankTransaction item)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.AddBankTransaction(item);
                return StatusCode((int)HttpStatusCode.Created, result);

            });
        }

        [HttpPost("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus([FromBody] BankTransaction item)
        {
            return await TryExecuteAction(async () =>
            {
                appService.UpdateStatus(item);
                return StatusCode((int)HttpStatusCode.OK);

            });
        }

        [HttpPost("CancelBankTransaction")]
        public async Task<IActionResult> CancelBankTransaction([FromBody] BankTransaction item)
        {
            return await TryExecuteAction(async () =>
            {
                appService.CancelBankTransaction(item);
                return StatusCode((int)HttpStatusCode.OK);

            });
        }

        [HttpGet("GetAllBankTransaction")]
        public async Task<IActionResult> GetAllBankTransaction(int _offset = 1, int _limit = 10)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.GetAllBankTransaction(_offset, _limit);
                return StatusCode((int)HttpStatusCode.Created, result);

            });
        }

        [HttpGet("GetBankTransactionByCode")]
        public async Task<IActionResult> GetBankTransactionByCode(Guid code)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.GetBankTransactionByCode(code);
                return StatusCode((int)HttpStatusCode.Created, result);

            });
        }

        //public async Task<IActionResult> GetBankTransactionByFilter(Expression<Func<BankTransaction, bool>> predicate)
        //{
        //    return await TryExecuteAction(async () =>
        //    {
        //        var result = await appService.AddMoneyTransfer(item);
        //        return StatusCode((int)HttpStatusCode.Created, result);

        //    });
        //    return await _bankTransactionService.GetBankTransactionByFilter(predicate);
        //}

    }
}