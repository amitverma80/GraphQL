using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLProject.Repository
{
    public class EmployeeRepository
    {
        private readonly List<Models.Employee> _employee = new List<Models.Employee>();

        public EmployeeRepository()
        {
            Models.Employee employee1 = new Models.Employee
            {
                Id = 1,
                FirstName = "First Name 1",
                LastName = "Last Name 1",
                Salary = 1000
            };
            Models.Employee employee2 = new Models.Employee
            {
                Id = 2,
                FirstName = "First Name 2",
                LastName = "Last Name 2",
                Salary = 2000
            };
            Models.Employee employee3 = new Models.Employee
            {
                Id = 3,
                FirstName = "First Name 3",
                LastName = "Last Name 3",
                Salary = 3000
            };




            _employee.Add(employee1);
            _employee.Add(employee2);
            _employee.Add(employee3);
        }

        public List<Models.Employee> GetAll()
        {
            return _employee;
        }

        public Models.Employee GetById(int id)
        {
            return _employee.Where(x => x.Id == id).FirstOrDefault();
        }


    }
}
