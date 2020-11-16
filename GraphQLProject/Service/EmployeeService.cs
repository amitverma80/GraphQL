using GraphQLProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLProject.Service
{
    public class EmployeeService
    {
        private EmployeeRepository _employeeRepository ;
        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<Models.Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Models.Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }
    }
}
