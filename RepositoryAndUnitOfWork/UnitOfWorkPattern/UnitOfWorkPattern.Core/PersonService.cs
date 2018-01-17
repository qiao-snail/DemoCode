using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPattern.EntityFramework;

namespace UnitOfWorkPattern.Core
{
    public class PersonService
    {
        private UnitOfWork unit;

        public PersonService(UnitOfWork unitOfWork)
        {
            unit = unitOfWork;
        }

        public IEnumerable<TPerson> Get()
        {

            return unit.PersonRepository.Get();
        }


        public bool AddPerson(TPerson p)
        {
            try
            {
                unit.PersonRepository.Insert(p);
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
                unit.PersonRepository.Update(p);
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
                unit.PersonRepository.Delete(p);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }

}
