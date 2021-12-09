using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApi.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static List<Employee> employees = new List<Employee>();
        private int _nextId = 1;

        public EmployeeRepository()
        {
            Add(new Employee { FirstName = "Manisha", LastName = "Bade", Address = "Pune" });
            Add(new Employee { FirstName = "John", LastName = "jssj", Address = "London" });
            Add(new Employee { FirstName = "Lily", LastName = "bsajdh", Address = "Paris" });

        }
        public Employee Add(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("employee");
            }
            employee.Id = _nextId++;
            employees.Add(employee);
            return employee;
        }

        public void Delete(int id)
        {
            employees.RemoveAll(e => e.Id == id);
        }

        public Employee Get(int id)
        {
            return employees.Find(e => e.Id == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return employees;
        }

        public bool Update(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("person");
            }

            int index = employees.FindIndex(p => p.Id == employee.Id);
            if (index == -1)
            {
                return false;
            }
            employees.RemoveAt(index);
            employees.Add(employee);
            return true;
        }
    }
}
