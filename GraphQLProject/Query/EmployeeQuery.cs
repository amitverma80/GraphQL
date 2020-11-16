using GraphQL.Types;
using GraphQLProject.OType;

namespace GraphQLProject.Query
{
    public class EmployeeQuery : ObjectGraphType
    {
        public EmployeeQuery(Service.EmployeeService employeeService)
        {
            int id = 0;

            Field<ListGraphType<EmployeeType>>(
                name: "employees", resolve: context =>
                {
                    return employeeService.GetAll();
                });

            Field<EmployeeType>(
                name: "employee",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    id = context.GetArgument<int>("id");
                    return employeeService.GetById(id);
                });
        }
    }
}
