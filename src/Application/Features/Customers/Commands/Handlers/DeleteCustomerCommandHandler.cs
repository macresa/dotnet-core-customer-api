using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Customers.Commands.Handlers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository repo;

        public DeleteCustomerCommandHandler(ICustomerRepository repo)
        {
            this.repo = repo;
        }

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await repo.Get().Where(c => c.Id == request.Id).AnyAsync();

            if (entity == false) throw new KeyNotFoundException($"Id {request.Id} was not found");

            await repo.Delete(request.Id);

            return;
        }
    }
}
