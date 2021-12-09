using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeWebApi.Models;
using System.Net;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        static readonly IEmployeeRepository repository = new EmployeeRepository();

        [HttpGet]
        public IEnumerable<Employee> GetAllEmployees()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public Employee GetEmployee(int id)
        {
            Employee item = repository.Get(id);

            if (item == null)
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
            }

            return item;
        }

        [HttpPost]
        public string PostEmployee(Employee item)
        {
            item = repository.Add(item);

            return "Added successfully";
        }

        [HttpPut("{id}")]

        public void PutEmployee(int id, Employee employee)
        {
            employee.Id = id;
            if (!repository.Update(employee))
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [HttpDelete("{id}")]

        public void DeleteEmployee(int id)
        {
            Employee item = repository.Get(id);

            if (item == null)
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Delete(id);
        }

    }
}
