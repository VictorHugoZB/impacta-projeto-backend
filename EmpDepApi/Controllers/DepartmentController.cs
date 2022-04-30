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
    public class DepartmentController : ApiController
    {
        // GET: Department
        [Route("api/department")]
        public HttpResponseMessage GetDepartamentos()
        {
            try
            {
                using (var db = new EmpresaContext())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, db.Departments.ToList());
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Request.CreateResponse(HttpStatusCode.Conflict, "Erro ao acessar servidor");
            }
            
        }

        // GET: Specific Department
        [Route("api/department/{id}")]
        public HttpResponseMessage GetDepartamento(int id)
        {
            try
            {
                using (var db = new EmpresaContext())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, db.Departments.Find(id));
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Request.CreateResponse(HttpStatusCode.Conflict, "Erro ao encontrar departamento.");
            }
        }

        [HttpPost]
        [Route("api/department/")]
        public HttpResponseMessage PostDepartamento(Department departamento)
        {
            try {
                using (var db = new EmpresaContext())
                {
                    db.Departments.Add(departamento);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, $"Departamento {departamento.Departamento} adicionado com sucesso.");
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro ao adicionar departamento.");
            }
            
        }

        [HttpPut]
        [Route("api/department/")]
        public HttpResponseMessage PutDepartamento(Department departamento)
        {
            try
            {
                using (var db = new EmpresaContext())
                {
                    db.Entry(departamento).State = EntityState.Modified;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Alteração feita com sucesso.");
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro ao realizar alteração.");
            }
            
        }

        [HttpDelete]
        [Route("api/department/{id}")]
        public HttpResponseMessage DeleteDepartamento(int id)
        {
            try
            {
                using (var db = new EmpresaContext())
                {
                    Department depToDelete = db.Departments.Find(id);
                    db.Departments.Remove(depToDelete);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Departamento deletado com sucesso.");
                }
            } catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e);
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro ao deletar departamento.");
            }
        }
    }
}