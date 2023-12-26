using System;
using System.Reflection;
using StudentsInterestSystem.Data;
using StudentsInterestSystem.ViewModels;

namespace StudentsInterestSystem.Models
{
	public class StudentRepo
	{
        private readonly StudentsDbContext _db;
        public StudentRepo(StudentsDbContext cx)
        {
            this._db = cx;
        }

        public bool AddStudent(Student student)
		{
			
			var std = _db.Students.FirstOrDefault(i => i.RollNo == student.RollNo || i.Email == student.Email);
			if(std != null)
			{
				return false;
			}
			else
			{
				_db.Students.Add(student);
				_db.SaveChanges();
				return true;
			}
		}
		public List<String> getAllInterests()
		{
			var interests = _db.Students.Select(i => i.Interest).ToList();
			interests = interests.Distinct().ToList();
			return interests;
		}
		public List<Student> getAllStudents()
		{
			return _db.Students.ToList();
		}
		public Student? getStudentById(int id)
		{
			var student = _db.Students.Find(id);
			return student;
		}
		public bool editStudent(EditStudentViewModel student)
		{
			var existingStd = _db.Students.Find(student.Id);
			if(existingStd != null)
			{
				existingStd.Name = student.Name;
				existingStd.RollNo = student.RollNo;
				existingStd.Email = student.Email;
				existingStd.Gender = student.Gender;
				existingStd.DOB = student.DOB;
				existingStd.City = student.City;
				existingStd.Interest = student.Interest == "other" ? student.stdInterest : student.Interest;
                existingStd.Department = student.Department;
				existingStd.DegreeTitle = student.DegreeTitle;
				existingStd.Subject = student.Subject;
				existingStd.StartDate = student.StartDate;
				existingStd.EndDate = student.EndDate;
				_db.SaveChanges();
				return true;
            }
			else
			{
				return false;
			}
		}
		public bool deleteStudent(int id)
		{
			var std = _db.Students.Find(id);
			if(std != null)
			{
                _db.Students.Remove(std);
                _db.SaveChanges();
				return true;
            }
			else
			{
				return false;
			}
		}
		public void delAll()
		{
			_db.Students.RemoveRange(_db.Students.ToList());
			_db.SaveChanges();
		}

		public List<List<String>> InterestsStats()
		{
			var interests = _db.Students.Select(i => i.Interest).ToList();

			var groupedInterests = interests.GroupBy(i => i).OrderByDescending(g => g.Count())
				.Select(g => new { Number = g.Key, Count = g.Count() }).ToList();

			var top5Interests = groupedInterests.Take(5).Select(g => g.Number).ToList();

            var bottom5Interests = groupedInterests.TakeLast(5).Select(g => g.Number).ToList();

			var result = new List<List<String>>() { top5Interests, bottom5Interests };
			return result;
        }

		public List<int> getAges()
		{
			var ages = new List<int>();
			var DOBs = _db.Students.Select(std => std.DOB).ToList();
			foreach(var dob in DOBs)
			{
				ages.Add(GetAge(dob));
			}
			return ages;
		}
        public int GetAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

		public Dictionary<string,int> calculateStudentsStatus()
		{
			var students = _db.Students.ToList();
			var stats = new Dictionary<string, int>()
			{
				{ "studying", 0 },
				{ "recently_enrolled", 0 },
				{ "about_to_graduate", 0 },
				{ "graduated", 0 }
			};
            DateTime today = DateTime.Today;

            foreach (Student student in students)
            {
                if (student.StartDate < today && student.EndDate > today)
                {
                    stats["studying"]++;
                }

                if (student.StartDate <= today && today.Subtract(student.StartDate).Days <= 30)
                {
                    stats["recently_enrolled"]++;
                }

				if (student.EndDate.Subtract(today).Days <= 365)
                {
                    stats["about_to_graduate"]++;
                }

				if (student.EndDate < today)
                {
                    stats["graduated"]++;
                }
            }

            return stats;
        }
    }
}

