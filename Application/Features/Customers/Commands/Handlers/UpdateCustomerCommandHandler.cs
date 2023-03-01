using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Customers.Commands.Handlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository repo;

        public UpdateCustomerCommandHandler(ICustomerRepository repo)
        {
            this.repo = repo;
        }

        public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer;

            try
            {
                customer = await repo.Get()
                    .Where(c => c.Id == request.Id)
                    .IgnoreAutoIncludes()
                    .FirstAsync();
            }
            catch{ throw new KeyNotFoundException($"Id {request.Id} was not found"); }

            if (request.Customer.Name != null)
            {
                customer.Name = request.Customer.Name;
            }

            if (request.Customer.Email != null)
            {
                customer.Email = request.Customer.Email;
            }

            if (request.Customer.PhoneNumber != null)
            {
                customer.PhoneNumber = request.Customer.PhoneNumber;
            }

            await repo.SaveChangesAsync();

            return;
        }
    }
}
