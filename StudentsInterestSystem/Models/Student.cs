using System;
using System.ComponentModel.DataAnnotations;

namespace StudentsInterestSystem.Models
{
	public class Student
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string RollNo { get; set; }
		public string Email { get; set; }
		public string Gender { get; set; }
		public DateTime DOB { get; set; }
		public string City { get; set; }
		public string Interest { get; set; }
		public string Department { get; set; }
		public string DegreeTitle { get; set; }
		public string Subject { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}

