using Application.DTOS;
using MediatR;

namespace Application.Features.Customers.Commands
{
    public sealed record CreateCustomerCommand(CreateCustomerDto Customer) : IRequest;
}
