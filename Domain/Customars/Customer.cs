using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Customars
{
    public class Customer : Entity
    {
        public string Email { get; private set; }
        public string Name { get; private set; }
    }
}
