using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLProject.OType
{
    public class EmployeeType : ObjectGraphType<Models.Employee>
    {
        public EmployeeType()
        {
            Name = "Employee";
            Field(_ => _.Id).Description("Employee Id");
            Field(_ => _.FirstName).Description("Employee First Name");
            Field(_ => _.LastName).Description("Employee Last Name");
            Field(_ => _.Salary).Description("Employee Salary");
        }
    }
}
