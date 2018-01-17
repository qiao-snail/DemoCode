using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkPattern.Application.ViewModels
{
    public class PersonVM
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Home { get; set; }
    }
}
