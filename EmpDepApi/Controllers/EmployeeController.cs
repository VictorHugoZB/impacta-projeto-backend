using EmpDepApi.Context;
using EmpDepApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace EmpDepApi.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: Employee
        [HttpGet]
        [Route("api/employee/")]
        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                using (var db = new EmpresaContext())
                {
                    return db.Employees.ToList();
                }
            } catch(Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e);
                return null;
            }
        }

        // GET: Specific Employee
        [Route("api/employee/{id}")]
        public Employee GetEmployee(int id)
        {
            try
            {
                using (var db = new EmpresaContext())
                {
                    return db.Employees.Find(id);
                }
            } catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e);
                return null;
            }
            
        }

        // GET: Specific Employee
        [Route("api/employee/ListarNomesDepartamentos")]
        public IEnumerable<Department> GetDepartmentsList()
        {
            try
            {
                using (var db = new EmpresaContext())
                {
                    return db.Departments.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e);
                return null;
            }
        }



        [HttpPost]
        [Route("api/employee/")]
        public Employee PostEmployee(Employee empregado)
        {
            using (var db = new EmpresaContext())
            {
                try
                {
                    db.Employees.Add(empregado);
                    db.SaveChanges();
                    return empregado;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                    return null;
                }
            }
        }

        [HttpPut]
        [Route("api/employee/")]
        public string PutDepartamento(Employee empregado)
        {
            try
            {
                using (var db = new EmpresaContext())
                {
                    db.Entry(empregado).State = EntityState.Modified;
                    db.SaveChanges();
                    return "Modificação feita com sucesso";
                }
            } catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e);
                return "Erro ao realizar alteração.";
            }
            
        }

        [HttpDelete]
        [Route("api/employee/{id}")]
        public Employee DeleteDepartamento(int id)
        {
            try
            {
                using (var db = new EmpresaContext())
                {
                    Employee empToDelete = db.Employees.Find(id);
                    db.Employees.Remove(empToDelete);
                    db.SaveChanges();
                    return empToDelete;
                }
            } catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e);
                return null;
            }
            
        }
    }
}