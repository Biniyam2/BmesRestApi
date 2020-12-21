using BmesRestApi.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BmesRestApi.Database;

namespace BmesRestApi.Repositories.Implementations
{
    public class PersonResository : IPersonRepositery
    {
        private readonly BmesDbContext _bmesDbContext;
        public PersonResository(BmesDbContext bmesDbContext)
        {
            _bmesDbContext = bmesDbContext;
        }
        public void DeletePerson(Person person)
        {
            _bmesDbContext.people.Remove(person);
            _bmesDbContext.SaveChanges();
        }

        public void EditPerson(Person person)
        {
            _bmesDbContext.people.Update(person);
            _bmesDbContext.SaveChanges();
        }

        public Person FindPersonById(long Id)
        {
            var person = _bmesDbContext.people.Find(Id);
            return person;
        }

        public IEnumerable<Person> GetPeople()
        {
            var people = _bmesDbContext.people;
            return people;
        }

        public void SavePerson(Person person)
        {
            _bmesDbContext.people.Add(person);
            _bmesDbContext.SaveChanges();
        }
    }
}
