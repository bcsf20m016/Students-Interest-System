using System;
using Microsoft.EntityFrameworkCore;
using StudentsInterestSystem.Models;

namespace StudentsInterestSystem.Data
{
	public class StudentsDbContext : DbContext
	{
		public StudentsDbContext()
		{
		}

        public StudentsDbContext(DbContextOptions options) : base(options)
        {
        }

		public DbSet<Student> Students { get; set; }
        public DbSet<ActionLogger> ActionsLogger { get; set; }
    }
}

