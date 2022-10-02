using Application.Abstractions.Currency;
using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Entities = Domain.Entities.Bills; 

namespace Application.VehicleBill.Commands.CreateVehicleBill
{
    public class CreateVehicleBillCommandHandler: ICommandHandler<CreateVehicleBillCommand, Guid>
    {
        private readonly IVehicleBillRepository _vehicleBillRepository;
        private readonly IBillRepository _billRepository;
        private readonly ICurrencyClient _currencyClient;

        private static double damageTax = 2500;
        private static double fuelTax = 400;

        public CreateVehicleBillCommandHandler(IVehicleBillRepository vehicleBillRepository, IBillRepository billRepository, ICurrencyClient currencyClient)
        {
            _vehicleBillRepository = vehicleBillRepository;
            _billRepository = billRepository;
            _currencyClient = currencyClient;
        }

        public async Task<Guid> Handle(CreateVehicleBillCommand request, CancellationToken cancellationToken)
        {
            var bill = await _billRepository.GetByIdAsync(request.BillId);

            var vehicleBill = new Entities.VehicleBill(Guid.NewGuid())
            {
                IsCarDamaged = request.IsCarDamaged,
                IsTankEmpty = request.IsTankEmpty,
                BillId = request.BillId,
            };

            if (request.IsTankEmpty)
            {
                bill.Price += (await _currencyClient.Convert(new Dto.CurrencyConvertRequest { Amount = fuelTax, FromCurrency = "RON", ToCurrency = bill.Currency })).Result;
            }

            if (request.IsCarDamaged)
            {
                bill.Price += (await _currencyClient.Convert(new Dto.CurrencyConvertRequest { Amount = damageTax, FromCurrency = "RON", ToCurrency = bill.Currency })).Result;
            }

            await _vehicleBillRepository.InsertAsync(vehicleBill);
            await _billRepository.UpdateAsync(bill.Id, bill);
            return vehicleBill.Id;

        }
    }
}
