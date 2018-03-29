using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalMVC.Models
{
	public class User
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "This field is required")]
		[DataType(DataType.Password)]
		public string password { get; set; }
	}
}