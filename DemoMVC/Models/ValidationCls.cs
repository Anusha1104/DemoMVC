using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class ValidationCls
    {
        string firstName;
        string lastName;
        double salary;
        string pancard;
        string password;
        string Confirmpassword;
        string phone;
        string email;
        DateTime doj;

        [Required(ErrorMessage ="First Name is must")]
        [StringLength(maximumLength:25,ErrorMessage ="Max Length is 25 only")]
        public string FirstName { get => firstName; set => firstName = value; }
        [Required(ErrorMessage = "Last Name is must")]
        public string LastName { get => lastName; set => lastName = value; }
       
        [Required(ErrorMessage ="Salary is must")]
        [Range(10000,20000,ErrorMessage ="sal btwn 10000 and 20000")]
        public double Salary { get => salary; set => salary = value; }
       
        [Required(ErrorMessage ="is must")]
        [RegularExpression("^[A-Z]{5}[0-9]{4}[A-z]$",ErrorMessage ="not a valid pan number")]
        public string Pancard { get => pancard; set => pancard = value; }
        
        [Required(ErrorMessage ="must")]
       
        public string Password { get => password; set => password = value; }
        
        [Required(ErrorMessage ="must")]
        [Compare("Password",ErrorMessage ="didnot match")]
        public string Confirmpassword1 { get => Confirmpassword; set => Confirmpassword = value; }
        
        [Phone(ErrorMessage ="not a valid num")]
        [MinLength(10,ErrorMessage ="10 digits only")]
        [MaxLength(10, ErrorMessage = "10 digits only")]
        public string Phone { get => phone; set => phone = value; }
        
        [EmailAddress(ErrorMessage ="not a valid email")]
        public string Email { get => email; set => email = value; }

       
        [CustomDoj] 
        public DateTime Doj { get => doj; set => doj = value; }
    }
}