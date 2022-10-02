using Entities = Domain.Entities;

using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Application.Abstractions.Currency;
using Application.Dto;

namespace Application.Bills.Commands.CreateBill
{
    public class CreateBillCommandHandler : ICommandHandler<CreateBillCommand, Guid>
    {
        private readonly IBillRepository _billRepository;
        private readonly ICurrencyClient _currencyClient;
        private readonly IOrderRepository _orderRepository;

        public CreateBillCommandHandler(IBillRepository billRepository, ICurrencyClient currencyClient, IOrderRepository orderRepository)
        {
            _billRepository = billRepository;
            _currencyClient = currencyClient;
            _orderRepository = orderRepository;
        }

        public async Task<Guid> Handle(CreateBillCommand request, CancellationToken cancellationToken)
        {
            var existingBills = (await _billRepository.GetAsync(x => x.OrderId == request.OrderId)).Count();

            if (existingBills > 0)
            {
                throw new Exception($"This bill already exists");
            }

            var order = await _orderRepository.GetByIdAsync(request.OrderId, nameof(Entities.Items.Item));

            var bookedDays = (order.EndDate - order.StardDate).TotalDays;

            var price = bookedDays * order.Item.Price;

            var currencyDto = new CurrencyConvertRequest
            {
                Amount = price,
                FromCurrency = "RON",
                ToCurrency = request.Currency
            };

            if (!request.Currency.Equals("RON")) 
            { 
               price = (await _currencyClient.Convert(currencyDto)).Result;
            }


            var bill = new Entities.Bills.Bill(id: Guid.NewGuid())
            {
                OrderId = request.OrderId,
                CustomerId = request.CustomerId,
                UserId = request.UserId,
                Currency = request.Currency,
                Price = price
            };

            await _billRepository.InsertAsync(bill);

            return bill.Id;


            //injectezi serviciul nou pt currency
            // 1. aduci order-ul din baza de date cu include de item
            // 2. faci diferenta intre date sa vezi nr de zile, datele sunt in order
            // 3. inmultesti nr de zile cu price-ul si ai total in lei
            // 4. faci call de serviciu sa convertesti in currency primit din request
            // 5 seteezi price ca bill.Price =
        }
    }
}
