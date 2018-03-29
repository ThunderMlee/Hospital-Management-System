using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalMVC.Models
{
	public class VisitContext:DbContext
	{
		public DbSet<Visit> Visits { get; set; }
	}
}