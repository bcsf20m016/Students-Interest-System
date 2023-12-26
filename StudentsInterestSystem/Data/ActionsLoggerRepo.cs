using System;
using StudentsInterestSystem.Models;

namespace StudentsInterestSystem.Data
{
	public class ActionsLoggerRepo
	{
        private readonly StudentsDbContext _db;

        public ActionsLoggerRepo(StudentsDbContext cx)
		{
			this._db = cx;
		}

		public void saveRecord(DateTime date, string action)
		{
			var actionLogger = new ActionLogger()
			{
				ActionDateTime = date,
				ActionDetail = action
			};
			_db.ActionsLogger.Add(actionLogger);
			_db.SaveChanges();
		}

		public Dictionary<DateTime,int> calculateSubmissions()
		{
            var startDate = DateTime.Today.AddDays(-30);
            var newStudentsByDate = _db.ActionsLogger
			.Where(i => i.ActionDateTime >= startDate && i.ActionDetail == "Student added successfully")
			.GroupBy(i => i.ActionDateTime.Date)
			.Select(group => new { Date = group.Key, Count = group.Count() })
			.OrderBy(item => item.Date)
			.ToDictionary(item => item.Date, item => item.Count);

            return newStudentsByDate;
        }

        public Dictionary<DateTime, int> calculateActions()
        {
            var startDate = DateTime.Today.AddDays(-30);
            var newActivitiesByDate = _db.ActionsLogger
            .Where(i => i.ActionDateTime >= startDate)
            .GroupBy(i => i.ActionDateTime.Date)
            .Select(group => new { Date = group.Key, Count = group.Count() })
            .OrderBy(item => item.Date)
            .ToDictionary(item => item.Date, item => item.Count);

            return newActivitiesByDate;
        }

        public Dictionary<string, int> calculateLastDaysActivities()
        {
            var startDate = DateTime.Now.AddHours(-24);

            var activitiesByHour = _db.ActionsLogger
                .Where(i => i.ActionDateTime >= startDate)
                .GroupBy(i => i.ActionDateTime.Hour)  // Group by hour for hourly data
                .Select(group => new { Hour = group.Key, Count = group.Count() })
                .OrderBy(item => item.Hour)
                .ToDictionary(item => FormatHour(item.Hour), item => item.Count);

            return activitiesByHour;
        }

        public List<List<String>> calculateMostLeastHours()
        {
            var startDate = DateTime.Today.AddDays(-30);
            var a = _db.ActionsLogger.Where(i => i.ActionDateTime >= startDate)
                .GroupBy(i => i.ActionDateTime.Hour)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .ToList();

            var mostActiveHours = a.Take(5).Select(i => FormatHour(i)).ToList();
            var leastActiveHours = a.TakeLast(5).Select(i => FormatHour(i)).ToList();
            return new List<List<String>> { mostActiveHours,leastActiveHours};
        }
        private string FormatHour(int hour)
        {
            return $"{(hour % 12 == 0 ? 12 : hour % 12)}:00 {(hour < 12 ? "AM" : "PM")}";
        }
    }
}

