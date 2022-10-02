using Application.Item.Commands.CreateItem;
using Application.Item.Commands.DeleteItem;
using Application.Item.Commands.UpdateItem;
using Application.VehicleItem.Commands.CreateVehicleItem;
using Application.VehicleItem.Commands.DeleteVehicleItems;
using Application.VehicleItem.Commands.UpdateVehicleItems;
using Application.VehicleItem.Queries.GetAllVehicleItems;
using Application.VehicleItem.Queries.GetVehicleItemById;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class VehicleItemController : ApiController
    {
        [HttpGet("{vehicleItemId:guid}")]
        public async Task<IActionResult> GetVehicleItemById([FromRoute] Guid vehicleItemId , CancellationToken cancellationToken)
        {
            var command = new GetVehicleItemQuery
            {
                Id = vehicleItemId
            };

            var response = await Sender.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicleItems(CancellationToken cancellationToken)
        {
            var command = new GetVehicleItemsQuery();

            var response = await Sender.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicleItem([FromBody] CreateVehicleItemCommandRequest request, CancellationToken cancellationToken)
        {
            var itemCommand = new CreateItemCommand
            {
                Price = request.Price,
                Type = request.ItemType
            };

            var itemId = await Sender.Send(itemCommand, cancellationToken);

            var vehicleItemCommand = new CreateVehicleItemCommand
            {
                ItemId = itemId,
                VehicleType = request.VehicleType,
                Model = request.Model,
                Brand = request.Brand
            };

            var vehicleItemId = await Sender.Send(vehicleItemCommand, cancellationToken);

            return CreatedAtAction(nameof(GetVehicleItemById), new { vehicleItemId }, vehicleItemId);
        }

        [HttpDelete("{vehicleItemId:guid}")]
        public async Task<IActionResult> DeleteVehicleItem([FromRoute] Guid vehicleItemId, CancellationToken cancellationToken)
        {
            var vehicleItemCommand = new DeleteVehicleItemCommand
            {
                Id = vehicleItemId
            };

            var itemId = await Sender.Send(vehicleItemCommand, cancellationToken);

            var itemCommand = new DeleteItemCommand
            {
                Id = itemId
            };

            await Sender.Send(itemCommand, cancellationToken);

            return NoContent();
        }


        [HttpPut("{vehicleItemId:guid}")]
        public async Task<IActionResult> UpdateVehicleItem([FromRoute] Guid vehicleItemId, [FromBody] UpdateVehicleItemCommandRequest request, 
            CancellationToken cancellationToken)
        {
            var vehicleItemCommand = new UpdateVehicleItemCommand
            {
                Id = vehicleItemId,
                Brand = request.Brand,
                Model = request.Model
            };

            var itemId = await Sender.Send(vehicleItemCommand, cancellationToken);

            var itemCommand = new UpdateItemCommand
            {
                Id = itemId,
                Price = request.Price
            };

            await Sender.Send(itemCommand, cancellationToken);

            return Ok();
        }

    }
}
