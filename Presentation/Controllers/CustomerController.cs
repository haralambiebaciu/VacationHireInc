using Application.Customer.Commands.CreateCustomer;
using Application.Customer.Commands.DeleteCustomer;
using Application.Customer.Commands.UpdateCustomer;
using Application.Customer.Queries.GetAllCustomers;
using Application.Customer.Queries.GetCustomerById;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet("{customerId:guid}")]
        public async Task<IActionResult> GetCustomer(Guid customerId, CancellationToken cancellationToken)
        {
            var customer = await Sender.Send(new GetCustomerQuery { Id = customerId }, cancellationToken);

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateCustomerCommand
            {
                Name = request.Name,
                Phone = request.Phone,
            };

            var customerId = await Sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetCustomer), new { customerId }, customerId);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers(CancellationToken cancellationToken)
        {
            var customers = await Sender.Send(new GetCustomersQuery(), cancellationToken);

            return Ok(customers);
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(Guid customerId, CancellationToken cancellationToken)
        {
            var command = new DeleteCustomerCommand()
            {
                Id = customerId
            };

            await Sender.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpPut("{customerId:Guid}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid customerId, [FromBody] UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateCustomerCommand()
            {
                Id = customerId,
                Name = request.Name,
                Phone = request.Phone
            };

            await Sender.Send(command, cancellationToken);

            return Ok();
        }
    }
}
