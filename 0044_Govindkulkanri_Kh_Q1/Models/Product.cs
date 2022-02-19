using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetExam_210940320044_KH.Models
{
    public class Product
    {
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "Product Name")]
        [Required(ErrorMessage ="{0} is an Required feild. Please fill it!!")]
        public string ProductName { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Rate")]
        [Required(ErrorMessage = "{0} is an Required feild. Please fill it!!")]
        public decimal Rate { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        [Required(ErrorMessage = "{0} is an Required feild. Please fill it!!")]

        public string Description { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "{0} is an Required feild. Please fill it!!")]

        public string CategoryName { get; set; }
    }
}