using BmesRestApi.Models.Customer;
using System.Collections.Generic;

namespace BmesRestApi.Repositories
{
    public interface ICustomerRepository
    {
        Customer FIndCustomerById(long Id);
        IEnumerable<Customer> Customers();
        void DeleteCustomer(Customer customer);
        void SaveCustomer(Customer customer);
        void EditCusotmer(Customer customer);
    }
}
