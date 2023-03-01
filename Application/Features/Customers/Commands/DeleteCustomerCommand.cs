using MediatR;

namespace Application.Features.Customers.Commands
{
    public sealed record DeleteCustomerCommand(int Id) : IRequest;
}
