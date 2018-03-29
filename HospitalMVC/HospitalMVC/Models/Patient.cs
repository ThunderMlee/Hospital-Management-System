using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HospitalMVC.Models
{
    [Table("patientTbl")]
    public class Patient : User
    {

        //public int Id { get; set; }
		[Required(ErrorMessage = "This field is required")]
		public string name { get; set; }
        public string address { get; set; }
        public string telephone { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public int doctorId { get; set; }
        public string VisitorHis { get; set; }
		[Required(ErrorMessage = "This field is required")]
		public string discharged { get; set; }

		//[Required(ErrorMessage = "This field is required")]
		//[DataType(DataType.Password)]
		//public string password { get; set; }
		
	}
}
