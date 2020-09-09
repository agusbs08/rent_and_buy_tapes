using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectUAS.Models
{
    public class RegisterMetadata
    {
        [Display(Name = "No Identitas")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "No Identitas required")]
        public string noIdentitas { get; set; }

        [Display(Name = "Username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username required")]
        public string username { get; set; }

        [Display(Name = "Nama")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nama required")]
        public string nama { get; set; }

        [Display(Name = "Alamat")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Alamat required")]
        public string alamat { get; set; }

        [Display(Name = "Saldo Awal")]
        [DataType(DataType.Currency)]
        public double saldo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password and password do not match")]
        public string ConfirmPassword { get; set; }
    }
}