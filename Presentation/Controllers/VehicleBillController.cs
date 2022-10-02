using Application.Bills.Commands.CreateBill;
using Application.Bills.Commands.DeleteBill;
using Application.Bills.Commands.UpdateBill;
using Application.VehicleBill.Commands.CreateVehicleBill;
using Application.VehicleBill.Commands.DeleteVehicleBill;
using Application.VehicleBill.Commands.UpdateVehicleBill;
using Application.VehicleBill.Queries.GetAllVehicleBills;
using Application.VehicleBill.Queries.GetVehicleBill;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class VehicleBillController : ApiController
    {
        [HttpGet("{vehicleBillId:guid}")]
        public async Task<IActionResult> GetVehicleBillById([FromRoute] Guid vehicleBillId, CancellationToken cancellationToken)
        {
            var query = new GetVehicleBillQuery
            {
                Id = vehicleBillId
            };

            var response = await Sender.Send(query, cancellationToken);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicleBills(CancellationToken cancellationToken)
        {
            var query = new GetVehicleBillsQuery();

            var response = await Sender.Send(query, cancellationToken);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicleBill([FromBody] CreateVehicleBillCommandRequest request, CancellationToken cancellationToken)
        {
            var billCommand = new CreateBillCommand
            {
                OrderId = request.OrderId,
                CustomerId = request.CustomerId,
                UserId = request.UserId,
                Currency = request.Currency
            };

            var billId = await Sender.Send(billCommand, cancellationToken);

            var vehicleBillCommand = new CreateVehicleBillCommand
            {
                BillId = billId,
                IsCarDamaged = request.IsCarDamaged,
                IsTankEmpty = request.IsTankEmpty
            };

            var vehicleBillId = await Sender.Send(vehicleBillCommand, cancellationToken);

            return CreatedAtAction(nameof(GetVehicleBillById), new { vehicleBillId }, vehicleBillId);
        }

        [HttpDelete("{vehicleBillId:guid}")]
        public async Task<IActionResult> DeleteVehiclebill([FromRoute] Guid vehicleBillId, CancellationToken cancellationToken)
        {
            var vehicleBillCommand = new DeleteVehicleBillCommand
            {
                Id = vehicleBillId
            };

            var billId = await Sender.Send(vehicleBillCommand, cancellationToken);

            var billCommand = new DeleteBillCommand
            {
                Id = billId
            };

            await Sender.Send(billCommand, cancellationToken);

            return NoContent();
        }


        [HttpPut("{vehicleBillId:guid}")]
        public async Task<IActionResult> UpdateVehicleItem([FromRoute] Guid vehicleBillId, [FromBody] UpdateVehicleBillCommandRequest request,
            CancellationToken cancellationToken)
        {
            var vehicleBillCommand = new UpdateVehicleBillCommand
            {
                Id = vehicleBillId,
                IsTankEmpty = request.IsTankEmpty,
                IsCarDamaged = request.IsCarDamaged,
            };

            var billId = await Sender.Send(vehicleBillCommand, cancellationToken);

            var itemCommand = new UpdateBillCommand
            {
                Id = billId,
                Currency = request.Currency
            };

            await Sender.Send(itemCommand, cancellationToken);

            return Ok();
        }
    }
}
