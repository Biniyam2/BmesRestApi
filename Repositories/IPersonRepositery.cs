using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BmesRestApi.Models.Shared;
namespace BmesRestApi.Repositories
{
    public interface IPersonRepositery
    {
        Person FindPersonById(long Id);
        IEnumerable<Person> GetPeople();
        void DeletePerson(Person person);
        void SavePerson(Person person);
        void EditPerson(Person person);
    }
}
