using EmpDepApi.Context;
using EmpDepApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace EmpDepApi.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: Employee
        [HttpGet]
        [Route("api/employee/")]
        public HttpResponseMessage GetEmployees()
        {
            try
            {
                using (var db = new EmpresaContext())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, db.Employees.ToList());
                }
            } catch(Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e);
                return Request.CreateResponse(HttpStatusCode.Conflict, "Erro ao acessar servidor");
            }
        }

        // GET: Specific Employee
        [Route("api/employee/{id}")]
        public HttpResponseMessage GetEmployee(int id)
        {
            try
            {
                using (var db = new EmpresaContext())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, db.Employees.Find(id));
                }
            } catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e);
                return Request.CreateResponse(HttpStatusCode.Conflict, "Erro ao acessar servidor");
            }
            
        }

        // GET: Rota para retornar lista de departamentos para preenchimento do droplist
        [Route("api/employee/ListarNomesDepartamentos")]
        public HttpResponseMessage GetDepartmentsList()
        {
            try
            {
                using (var db = new EmpresaContext())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, db.Departments.ToList());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e);
                return Request.CreateResponse(HttpStatusCode.Conflict, "Erro ao acessar servidor");
            }
        }



        [HttpPost]
        [Route("api/employee/")]
        public HttpResponseMessage PostEmployee(Employee empregado)
        {
            using (var db = new EmpresaContext())
            {
                try
                {
                    db.Employees.Add(empregado);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, $"Funcionario(a) {empregado.Nome} adicionado(a) com sucesso.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro ao acessar servidor");
                }
            }
        }

        [HttpPut]
        [Route("api/employee/")]
        public HttpResponseMessage PutDepartamento(Employee empregado)
        {
            try
            {
                using (var db = new EmpresaContext())
                {
                    db.Entry(empregado).State = EntityState.Modified;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Alteração feita com sucesso.");
                }
            } catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro ao realizar alteração.");
            }
            
        }

        [HttpDelete]
        [Route("api/employee/{id}")]
        public HttpResponseMessage DeleteDepartamento(int id)
        {
            try
            {
                using (var db = new EmpresaContext())
                {
                    Employee empToDelete = db.Employees.Find(id);
                    db.Employees.Remove(empToDelete);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Funcionario deletado com sucesso.");
                }
            } catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro ao deletar funcionario.");
            }
            
        }
    }
}