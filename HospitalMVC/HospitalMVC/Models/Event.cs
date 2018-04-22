using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace HospitalMVC.Models
{

    [Table("Events")]
    public class Event
    {
        public int EventID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public System.DateTime Start { get; set; }
        
        public Nullable<System.DateTime> End { get; set; }

        public string ThemeColor { get; set; }

        public bool IsFullDay { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string DoctorID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string PatientID { get; set; }
    }
}