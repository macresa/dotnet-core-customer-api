using Application.DTOS;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Customers.Querys.Handlers
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
    {
        private readonly ICustomerRepository repo;
        private readonly IMapper mapper;
        public GetAllCustomersHandler(ICustomerRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }        
        public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await mapper.ProjectTo<CustomerDto>(repo.Get()).AsNoTracking().ToListAsync();
        }
    }
}
