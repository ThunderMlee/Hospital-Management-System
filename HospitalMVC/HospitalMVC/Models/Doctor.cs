using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HospitalMVC.Models
{

	[Table("doctorTbl")]
	public class Doctor : User
	{
		[Required(ErrorMessage = "This field is required")]
		public string name { get; set; }
		[Required(ErrorMessage = "This field is required")]
		public string email { get; set; }
		[Required(ErrorMessage = "This field is required")]
		public string address { get; set; }
	}
}