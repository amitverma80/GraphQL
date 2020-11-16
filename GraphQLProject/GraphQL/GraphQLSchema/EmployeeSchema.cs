using GraphQL;
using GraphQL.Types;
using GraphQLProject.Query;

namespace GraphQLProject.GraphQL.GraphQLSchema
{
    public class EmployeeSchema : Schema
    {
        public EmployeeSchema(IDependencyResolver resolver):
            base(resolver)
        {
            Query = resolver.Resolve<EmployeeQuery>();
        }
    }
}
