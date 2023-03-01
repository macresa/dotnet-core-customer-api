using AutoMapper;
using Domain.Entities;

namespace Application.DTOS.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CreateCustomerDto, Customer>();
        }
    }
}
