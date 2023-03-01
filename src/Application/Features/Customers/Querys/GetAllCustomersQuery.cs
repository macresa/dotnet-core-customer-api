using Application.DTOS;
using MediatR;

namespace Application.Features.Customers.Querys
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<CustomerDto>>
    {
    }
}
