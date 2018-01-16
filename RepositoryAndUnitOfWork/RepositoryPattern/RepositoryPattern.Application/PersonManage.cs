using RepositoryPattern.Application.ViewModels;
using RepositoryPattern.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Application
{
    public class PersonManage
    {
        public IList<PersonVM> GetPersons()
        {
            var list = new PersonService().Get();
            var result = new List<PersonVM>();
            foreach (var item in list)
            {
                result.Add(new PersonVM { Name = item.Name, Age = item.Age, Home = item.Home, PersonID = item.Id });
            }
            return result;
        }

        public bool AddPerson(PersonVM p)
        {
            return new PersonService().AddPerson(new EntityFramework.TPerson { Name = p.Name, Home = p.Home, Age = p.Age, Id = p.PersonID });
        }

        public bool DeletePerson(PersonVM p)
        {
            return new PersonService().DeletePerson(new EntityFramework.TPerson { Name = p.Name, Home = p.Home, Age = p.Age, Id = p.PersonID });
        }

        public bool EditPerson(PersonVM p)
        {
            return new PersonService().EditPerson(new EntityFramework.TPerson { Name = p.Name, Home = p.Home, Age = p.Age, Id = p.PersonID });
        }
    }
}
