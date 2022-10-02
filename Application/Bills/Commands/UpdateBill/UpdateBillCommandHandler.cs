using Entities = Domain.Entities;

using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Application.Abstractions.Currency;

namespace Application.Bills.Commands.UpdateBill
{
    public class UpdateBillCommandHandler : ICommandHandler<UpdateBillCommand, Guid>
    {
        private readonly IBillRepository _billRepository;
        private readonly ICurrencyClient _currencyClientRepository;

        public UpdateBillCommandHandler(IBillRepository billRepository, ICurrencyClient currencyClient)
        {
            _billRepository = billRepository;
            _currencyClientRepository = currencyClient;
        }

        public async Task<Guid> Handle(UpdateBillCommand request, CancellationToken cancellationToken)
        {
            var bill = await _billRepository.GetByIdAsync(request.Id, nameof(Entities.Bills.VehicleBill));

            if (request.Currency != bill.Currency)
            {
                var conversionResult = await _currencyClientRepository.Convert(new Dto.CurrencyConvertRequest
                {
                    Amount = bill.Price,
                    FromCurrency = bill.Currency,
                    ToCurrency = request.Currency
                });

                bill.Price = conversionResult.Result;
                bill.Currency = request.Currency;
            }

            await _billRepository.UpdateAsync(bill.Id, bill);

            return request.Id;
        }
    }
}
