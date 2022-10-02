using Application.Abstractions.Currency;
using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Entities = Domain.Entities.Bills;

namespace Application.VehicleBill.Commands.UpdateVehicleBill
{
    public class UpdateVehicleBillCommandHandler : ICommandHandler<UpdateVehicleBillCommand, Guid>
    {
        private readonly IVehicleBillRepository _vehicleBillRepository;
        private readonly ICurrencyClient _currencyClient;

        private static double damageTax = 2500;
        private static double fuelTax = 400;

        public UpdateVehicleBillCommandHandler(IVehicleBillRepository vehicleBillRepository, ICurrencyClient currencyClient )
        {
            _vehicleBillRepository = vehicleBillRepository;
            _currencyClient = currencyClient;
        }

        public async Task<Guid> Handle(UpdateVehicleBillCommand request, CancellationToken cancellationToken)
        {
            var entity = await _vehicleBillRepository.GetByIdAsync(request.Id, nameof(Entities.Bill));

            bool tankEmptyAndModified = (request.IsTankEmpty != entity.IsTankEmpty && request.IsTankEmpty == true);

            bool tankNotEmptyAndModified = (request.IsTankEmpty != entity.IsTankEmpty && request.IsTankEmpty == false);

            bool carIsDamagedAndModified = (request.IsCarDamaged != entity.IsCarDamaged && request.IsCarDamaged);

            bool carIsNotDamagedAndModified = (request.IsCarDamaged != entity.IsCarDamaged && request.IsCarDamaged == false);

            var convertFuelTax = new Dto.CurrencyConvertRequest
            {
                Amount = fuelTax,
                FromCurrency = "RON",
                ToCurrency = entity.Bill.Currency
            };

            var convertDamageTax = new Dto.CurrencyConvertRequest
            {
                Amount = damageTax,
                FromCurrency = "RON",
                ToCurrency = entity.Bill.Currency
            };

            if (tankEmptyAndModified)
            {
                entity.Bill.Price += (await _currencyClient.Convert(convertFuelTax)).Result;
                entity.IsTankEmpty = request.IsTankEmpty;
            }

            if (tankNotEmptyAndModified)
            {
                entity.Bill.Price -= (await _currencyClient.Convert(convertFuelTax)).Result;
                entity.IsTankEmpty = request.IsTankEmpty;
            }

            if (carIsDamagedAndModified)
            {
                entity.Bill.Price += (await _currencyClient.Convert(convertDamageTax)).Result;
                entity.IsCarDamaged = request.IsCarDamaged;

            }

            if (carIsNotDamagedAndModified)
            {
                entity.Bill.Price -= (await _currencyClient.Convert(convertDamageTax)).Result;
                entity.IsCarDamaged = request.IsCarDamaged;
            }

            await _vehicleBillRepository.UpdateAsync(request.Id, entity);

            return entity.BillId;
        }
    }
}
