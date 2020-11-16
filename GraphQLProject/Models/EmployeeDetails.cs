using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLProject.Models
{
    public class EmployeeDetails
    {
        public int EmployeeId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public List<int> Mobile { get; set; }
    }
}
