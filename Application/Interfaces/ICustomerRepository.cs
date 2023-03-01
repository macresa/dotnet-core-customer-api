using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> Get();
        void Create(Customer customer);
        Task Delete(int id);
        Task SaveChangesAsync();
    }
}
