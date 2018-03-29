using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalMVC.Models
{
	[Table("visitTbl")]
	public class Visit
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "This field is required")]
		public int doctorId { get; set; }
		public int patientId { get; set; }
		public DateTime date { get; set; }
		public string details { get; set; }
	}
}