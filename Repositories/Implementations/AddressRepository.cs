using BmesRestApi.Models.Addresses;
using System.Collections.Generic;
using BmesRestApi.Database;

namespace BmesRestApi.Repositories.Implementations
{
    public class AddressRepository : IAddressRespository
    {
        private readonly BmesDbContext _bmesDbContext;
        public AddressRepository(BmesDbContext bmesDbContext)
        {
            _bmesDbContext = bmesDbContext;
        }
        public void DeleteAddress(Address address)
        {
            _bmesDbContext.Addresses.Remove(address);
            _bmesDbContext.SaveChanges();
        }

        public void EditAddress(Address address)
        {
            _bmesDbContext.Addresses.Update(address);
            _bmesDbContext.SaveChanges();
        }

        public Address FindAddressById(long Id)
        {
            var address = _bmesDbContext.Addresses.Find(Id);
            return address;
        }

        public IEnumerable<Address> GetAddresses()
        {
            var address =  _bmesDbContext.Addresses;
            return address;
        }

        public void SaveAddress(Address address)
        {
            _bmesDbContext.Addresses.Add(address);
            _bmesDbContext.SaveChanges();
        }
    }
}
