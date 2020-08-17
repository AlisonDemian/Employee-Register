using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmployeeRegister2._0.Models
{
    public class Employee
    {
        [Display(Name ="ID")]
        public int EmployeeId { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Adicione um nome!")]
        public string EmployeeFirstName { get; set; }
        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "Adicione um sobrenome!")]
        public string EmployeeLastName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Adicione um email!")]
        public string EmployeeEmail { get; set; }
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Adicione uma senha!")]
        [DataType(DataType.Password)]
        public string EmployeePassword { get; set; }
    }
}