namespace Application.Dto
{
    public class CurrencyConvertRequest
    {
        public string FromCurrency { get; set; }

        public string ToCurrency { get; set; }

        public double Amount { get; set; }
    }
}
