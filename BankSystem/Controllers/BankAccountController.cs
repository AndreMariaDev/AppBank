using Bank.Domain.Models;
using Bank.Infra.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BankSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : BaseController<BankAccount>
    {
        private readonly IBankAccountService appService;

        public BankAccountController(IBankAccountService appService)
        {
            this.appService = appService;
        }


        [HttpGet("ValidationBankAccount")]
        //[Authorize]
        public async Task<IActionResult> ValidationBankAccount(String accountNumber, String branch)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.ValidationBankAccount(accountNumber, branch);
                return StatusCode((int)HttpStatusCode.Created, result);

            });
        }

        [HttpPost("AddAccount")]
        public async Task<IActionResult> AddAccount([FromBody] BankAccount item)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.AddAccount(item);
                return StatusCode((int)HttpStatusCode.Created, result);

            });
        }

        [HttpPost("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount([FromBody] BankAccount item)
        {
            return await TryExecuteAction(async () =>
            {
                appService.UpdateAccount(item);
                return StatusCode((int)HttpStatusCode.OK);

            });
        }

        [HttpPost("DeleteAccount")]
        public async Task<IActionResult> DeleteAccount([FromBody] BankAccount item)
        {
            return await TryExecuteAction(async () =>
            {
                appService.DeleteAccount(item);
                return StatusCode((int)HttpStatusCode.OK);

            });
        }

        [HttpGet("GetAllAccounts")]
        public async Task<IActionResult> GetAllAccounts(int _offset = 1, int _limit = 10)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.GetAllAccounts(_offset, _limit);
                return StatusCode((int)HttpStatusCode.Created, result);

            });
        }

        [HttpGet("GetAccountsByCode")]
        public async Task<IActionResult> GetAccountsByCode(Guid code)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await appService.GetAccountsByCode(code);
                return StatusCode((int)HttpStatusCode.Created, result);

            });
        }

        //public async Task<IActionResult> GetAccountsByFilter(Expression<Func<BankAccount, bool>> predicate)
        //{
        //    return await TryExecuteAction(async () =>
        //    {
        //        var result = await appService.GetAccountsByFilter(predicate);
        //        return StatusCode((int)HttpStatusCode.Created, result);

        //    });
        //}
    }
}
