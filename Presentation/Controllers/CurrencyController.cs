using Application.Abstractions.Currency;
using Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class CurrencyController : ApiController
    {
        private readonly ICurrencyClient _currencyClient;

        public CurrencyController(ICurrencyClient currencyClient)
        {
            _currencyClient = currencyClient;
        }

        [HttpGet("convert")]
        public async Task<IActionResult> Convert([FromQuery(Name = "toCurrency")] string toCurrency,
            [FromQuery(Name = "fromCurrency")] string fromCurrency,
            [FromQuery(Name = "amount")] double amount)
        {

            var result = await _currencyClient.Convert(new CurrencyConvertRequest
            {
                ToCurrency = toCurrency,
                FromCurrency = fromCurrency,
                Amount = amount
            });

            return Ok(result);
        }
    }
}
