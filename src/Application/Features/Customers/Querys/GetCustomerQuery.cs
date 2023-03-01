using Application.DTOS;
using MediatR;

namespace Application.Features.Customers.Querys
{
    public sealed record GetCustomerQuery(int Id) : IRequest<CustomerDto>;
}
