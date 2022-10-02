using Application.Abstractions.Currency;
using Application.Dto;
using Newtonsoft.Json;

namespace Infrastructure.Services
{
    public class CurrencyClient : ICurrencyClient
    {
        private readonly HttpClient _httpClient;

        public CurrencyClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CurrencyConvertResponse> Convert(CurrencyConvertRequest request)
        {
            var response = await _httpClient.GetAsync($"currency_data/convert?to={request.ToCurrency}&from={request.FromCurrency}&amount={request.Amount}");

            if (!response.IsSuccessStatusCode)
            {

                throw new Exception("Call to currency api failed");
            }

            var responseDto = JsonConvert.DeserializeObject<CurrencyConvertResponse>(await response.Content.ReadAsStringAsync());

            return new CurrencyConvertResponse
            {
                Success = responseDto.Success,
                Result = responseDto.Result
            };
        }
    }
}
