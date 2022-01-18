using EmpDepApi.Context;
using EmpDepApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace EmpDepApi.Controllers
{
    public class DepartmentController : ApiController
    {
        // GET: Department
        [Route("api/department")]
        public IEnumerable<Department> GetDepartamentos()
        {
            try
            {
                using (var db = new EmpresaContext())
                {
                    return db.Departments.ToList();
                }
            } catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e);
                return null;
            }
            
        }

        // GET: Specific Department
        [Route("api/department/{id}")]
        public Department GetDepartamento(int id)
        {
            try
            {
                using (var db = new EmpresaContext())
                {
                    return db.Departments.Find(id);
                }
            } catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e);
                return null;
            }
        }

        [HttpPost]
        [Route("api/department/")]
        public Department PostDepartamento(Department departamento)
        {
            try {
                using (var db = new EmpresaContext())
                {
                    db.Departments.Add(departamento);
                    db.SaveChanges();
                    return departamento;
                }
            } catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e);
                return null;
            }
            
        }

        [HttpPut]
        [Route("api/department/")]
        public string PutDepartamento(Department departamento)
        {
            try
            {
                using (var db = new EmpresaContext())
                {
                    db.Entry(departamento).State = EntityState.Modified;
                    db.SaveChanges();
                    return "Atualização feita com sucesso!";
                }
            } catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e);
                return "Erro ao atualizar";
            }
            
        }

        [HttpDelete]
        [Route("api/department/{id}")]
        public Department DeleteDepartamento(int id)
        {
            try
            {
                using (var db = new EmpresaContext())
                {
                    Department depToDelete = db.Departments.Find(id);
                    db.Departments.Remove(depToDelete);
                    db.SaveChanges();
                    return depToDelete;
                }
            } catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e);
                return null;
            }
        }
    }
}