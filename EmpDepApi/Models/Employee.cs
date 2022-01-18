using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmpDepApi.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Departamento { get; set; }
        [Required]
        public string DataContratacao { get; set; }
        public string PathImagem { get; set; }
    }
}