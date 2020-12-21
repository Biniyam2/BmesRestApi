using BmesRestApi.Models.Customer;
using System;
using System.Collections.Generic;
using BmesRestApi.Database;

namespace BmesRestApi.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BmesDbContext _bmesDbContext;
        public CustomerRepository(BmesDbContext bmesDbContext)
        {
            _bmesDbContext = bmesDbContext;
        }
        public IEnumerable<Customer> Customers()
        {
            var customers = _bmesDbContext.Customers;
            return customers;
        }

        public void DeleteCustomer(Customer customer)
        {
            _bmesDbContext.Customers.Remove(customer);
            _bmesDbContext.SaveChanges();
        }

        public void EditCusotmer(Customer customer)
        {
            _bmesDbContext.Customers.Update(customer);
            _bmesDbContext.SaveChanges();
        }

        public Customer FIndCustomerById(long Id)
        {
           var customer = _bmesDbContext.Customers.Find(Id);
            return customer;
        }

        public void SaveCustomer(Customer customer)
        {
            _bmesDbContext.Customers.Add(customer);
            _bmesDbContext.SaveChanges();
        }
    }
}
