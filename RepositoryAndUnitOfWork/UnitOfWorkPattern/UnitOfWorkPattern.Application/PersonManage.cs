using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPattern.Application.ViewModels;
using UnitOfWorkPattern.Core;
using UnitOfWorkPattern.EntityFramework;

namespace UnitOfWorkPattern.Application
{
    public class PersonManage
    {
        public IList<PersonVM> GetPersons()
        {
            using (var unit = new UnitOfWork())
            {
                var list = new PersonService(unit).Get();
                var result = new List<PersonVM>();
                foreach (var item in list)
                {
                    result.Add(new PersonVM { Name = item.Name, Age = item.Age, Home = item.Home, PersonID = item.Id });
                }
                return result;
            }
        }

        public bool AddPerson(PersonVM p)
        {
            using (var unit = new UnitOfWork())
            {
                var result = new PersonService(unit).AddPerson(new EntityFramework.TPerson { Name = p.Name, Home = p.Home, Age = p.Age, Id = p.PersonID });
                unit.Save();
                return result;
            }
        }

        public bool DeletePerson(PersonVM p)
        {
            using (var unit = new UnitOfWork())
            {
                var result = new PersonService(unit).DeletePerson(new EntityFramework.TPerson { Name = p.Name, Home = p.Home, Age = p.Age, Id = p.PersonID });
                unit.Save();
                return result;
            }
        }

        public bool EditPerson(PersonVM p)
        {
            using (var unit = new UnitOfWork())
            {
                var result = new PersonService(unit).EditPerson(new EntityFramework.TPerson { Name = p.Name, Home = p.Home, Age = p.Age, Id = p.PersonID });
                unit.Save();
                return result;
            }
        }
    }

}
