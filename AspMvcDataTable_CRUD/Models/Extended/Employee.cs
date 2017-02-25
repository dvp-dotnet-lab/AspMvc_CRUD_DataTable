using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspMvcDataTable_CRUD.Models
{
    [MetadataType(typeof(EmployeeMetada))]
    public partial class Employee
    {

    }

    public class EmployeeMetada
    {
        [Required(AllowEmptyStrings = false , ErrorMessage = "Please provide first name")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide last name")]
        public string LastName { get; set; }

    }
}