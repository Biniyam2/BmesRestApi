using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BmesRestApi.Models.Addresses;

namespace BmesRestApi.Repositories
{
    public interface IAddressRespository
    {
        Address FindAddressById(long Id);
        IEnumerable<Address> GetAddresses();
        void DeleteAddress(Address address);
        void SaveAddress(Address address);
        void EditAddress(Address address);

    }
}
