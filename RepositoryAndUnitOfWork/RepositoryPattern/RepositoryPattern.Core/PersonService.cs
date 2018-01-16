using RepositoryPattern.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Core
{
    public class PersonService
    {

        public IEnumerable<TPerson> Get()
        {
            using (var context = new RepositoryDemoEntities())
            {
                return new EFBaseRepository<TPerson>(context).Get();
            }
        }


        public bool AddPerson(TPerson p)
        {
            try
            {
                using (var context = new RepositoryDemoEntities())
                {
                    new EFBaseRepository<TPerson>(context).Insert(p);
                }
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
                using (var context = new RepositoryDemoEntities())
                {
                    new EFBaseRepository<TPerson>(context).Update(p);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeletePerson(TPerson p)
        {
            try
            {

                using (var context = new RepositoryDemoEntities())
                {
                    new EFBaseRepository<TPerson>(context).Delete(p);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
