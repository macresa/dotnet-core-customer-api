using Application.DTOS;
using Application.Interfaces;
using Application.Middlewares;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Customers.Querys.Handlers
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, CustomerDto>
    {
        private readonly ICustomerRepository repo;
        private readonly IMapper mapper;
        public GetCustomerHandler(ICustomerRepository repo, IMapper mapper) 
        {
            this.repo = repo;
            this.mapper = mapper;
        }      
        public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await mapper.ProjectTo<CustomerDto>(repo.Get())
                .Where(c => c.Id == request.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (customer == null) throw new KeyNotFoundException($"Id {request.Id} was not found");

            return customer;
        }
    }
}
