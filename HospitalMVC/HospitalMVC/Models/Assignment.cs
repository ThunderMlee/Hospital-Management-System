//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Assignment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientFName { get; set; }
        public string PatientLName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorFName { get; set; }
        public string DoctorLName { get; set; }
    
        public virtual Profile Profile { get; set; }
        public virtual Profile Profile1 { get; set; }
    }
}