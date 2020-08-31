using EmployeeRegister2._0.DataAccess;
using EmployeeRegister2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
namespace EmployeeRegister2._0.Controllers
{
    public class EmployeeController : Controller
    {

        EmployeeDBAccess employeeDBAccess = new EmployeeDBAccess();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEmployee()
        {
                List<Employee> employeeList = new List<Employee>();
                employeeList = employeeDBAccess.GetEmployees().ToList();
                 return Json(new { data = employeeList }, JsonRequestBehavior.AllowGet); 
            
        } 


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeDBAccess.CreateEmployee(employee);

                // EMAIL SENDER
                /*
                MailMessage mail = new MailMessage();
                mail.To.Add(employee.EmployeeEmail); // Employee Email here (fake email in this case)
                mail.From = new MailAddress("Company Email HERE", "Email head", System.Text.Encoding.UTF8);
                mail.Subject = "Subject HERE";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = "(TESTE) Olá, sua conta foi atualizada no programa Funcionários.";
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("Company Email HERE", "Account password HERE");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                try
                {
                    client.Send(mail);    
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction("Index");
                */
            }

            return View(employee);
        }

        //GET (BY ID) TO UPDATE
        public ActionResult SearchEmployee(int id)
        {
            Employee employee = employeeDBAccess.GetEmployeeById(id);
            return Json(employee, JsonRequestBehavior.AllowGet);
        }


        //UPDATE
        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
           
            employeeDBAccess.UpdateEmployee(employee);
            return RedirectToAction("Index");
           
        }

        //GET TO DELETE
        /*
        public ActionResult Delete(int id)
        {
            Employee employee = employeeDBAccess.GetEmployeeById(id);
            return View(employee);
        }
        */

        //DELETE
        public void DeleteEmp(int id)
        {
            try
            {
                employeeDBAccess.DeleteEmployee(id);
            }
            catch (Exception)
            {
                throw;
            }

            
        }
    }
}