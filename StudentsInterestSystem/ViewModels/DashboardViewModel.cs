using System;
using StudentsInterestSystem.Models;

namespace StudentsInterestSystem.ViewModels
{
	public class DashboardViewModel
	{
		public List<string> TopInterests { get; set; }
        public List<string> BottomInterests { get; set; }
		public int DistinctInterests { get; set; }
		public List<int> Ages { get; set; }
		public List<Student> students { get; set; }
		public Dictionary<string,int> StudentStats { get; set; }
		public Dictionary<DateTime, int> Submissions { get; set; }
        public Dictionary<DateTime, int> Actions { get; set; }
        public Dictionary<string, int> ActionsByHour { get; set; }
        public List<string> MostActiveHours { get; set; }
        public List<string> LeastActiveHours { get; set; }

    }
}

