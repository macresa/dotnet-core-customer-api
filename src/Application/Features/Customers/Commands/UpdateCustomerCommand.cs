using Application.DTOS;
using MediatR;

namespace Application.Features.Customers.Commands
{
    public sealed record UpdateCustomerCommand(UpdateCustomerDto Customer, int Id) : IRequest;
 
}
