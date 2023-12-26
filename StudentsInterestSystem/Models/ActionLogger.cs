using System;
using System.ComponentModel.DataAnnotations;

namespace StudentsInterestSystem.Models
{
	public class ActionLogger
	{
		[Key]
		public int Id { get; set; }
		public DateTime ActionDateTime { get; set; }
		public string ActionDetail { get; set; }
	}
}

