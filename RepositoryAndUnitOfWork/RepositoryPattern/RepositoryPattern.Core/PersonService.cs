using RepositoryPattern.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Core
{
    public class PersonService
    {
        private EFBaseRepository<TPerson> _personRepository;

        public PersonService(DbContext dbContext)
        {
            var context = dbContext;
            _personRepository = new EFBaseRepository<TPerson>(context);
        }
        public IEnumerable<TPerson> Get()
        {
            return _personRepository.Get();
        }


        public bool AddPerson(TPerson p)
        {
            try
            {
                _personRepository.Insert(p);
            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }

        public bool EditPerson(TPerson p)
        {
            try
            {
                _personRepository.Update(p);

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool DeletePerson(TPerson p)
        {
            try
            {
                _personRepository.Delete(p);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
