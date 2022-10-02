using Application.Dto;

namespace Application.Abstractions.Currency
{
    public interface ICurrencyClient
    {
        Task<CurrencyConvertResponse> Convert(CurrencyConvertRequest request);
    }
}
