using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Infrastructure.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext db;
        public CustomerRepository(DataContext db) => this.db = db;
        public IQueryable<Customer> Get()
         => db.Set<Customer>();

        public void Create(Customer customer)
        {
            db.Set<Customer>().Add(customer);
        }
        public Task Delete(int id)
           => db.Set<Customer>().Where(c => c.Id == id).ExecuteDeleteAsync();
  
        public async Task SaveChangesAsync()
            => await db.SaveChangesAsync();
    }
}
