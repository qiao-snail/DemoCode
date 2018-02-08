using RepositoryPattern.Application.ViewModels;
using RepositoryPattern.Core;
using RepositoryPattern.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Application
{
    public class PersonManage
    {

        public bool IsConnect()
        {
            using (var context = new RepositoryDemoEntities())
            {
                return true;
            }
        }
        public IList<PersonVM> GetPersons()
        {
            using (var context = new RepositoryDemoEntities())
            {
                var list = new PersonService(context).Get();
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
            using (var context = new RepositoryDemoEntities())
            {
                context.Configuration.AutoDetectChangesEnabled = true;
                var result = new PersonService(context).AddPerson(new EntityFramework.TPerson { Name = p.Name, Home = p.Home, Age = p.Age, Id = p.PersonID });
                context.SaveChanges();
                return result;
            }



        }

        public bool DeletePerson(PersonVM p)
        {
            using (var context = new RepositoryDemoEntities())
            {
                var result = new PersonService(context).DeletePerson(new EntityFramework.TPerson { Name = p.Name, Home = p.Home, Age = p.Age, Id = p.PersonID });
                context.SaveChanges();
                return result;
            }
        }

        public bool EditPerson(PersonVM p)
        {
            using (var context = new RepositoryDemoEntities())
            {
                var result = new PersonService(context).EditPerson(new EntityFramework.TPerson { Name = p.Name, Home = p.Home, Age = p.Age, Id = p.PersonID });
                context.SaveChanges();
                return result;
            }
        }

        public bool AddPersons(List<PersonVM> persons)
        {
            var list = new List<TPerson>();
            persons.ForEach(p => list.Add(new TPerson
            { Name = p.Name, Home = p.Home, Age = p.Age, Id = p.PersonID }));
            using (var context = new RepositoryDemoEntities())
            {
                var result = new PersonService(context).AddPersons(list);
                context.SaveChanges();
                return result;
            }
        }
    }

}
