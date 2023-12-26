using System;
using StudentsInterestSystem.Models;

namespace StudentsInterestSystem.Data
{
	public class StudentsDbInitializer
	{
		public static void Seed(IApplicationBuilder applicationBuilder)
		{
			using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<StudentsDbContext>();

				context.Database.EnsureCreated();
				{ }
				if(!context.Students.Any())
				{
                    DateTime currentDate = DateTime.Now;
                    DateTime newStartDate = currentDate.AddDays(-20);
                    context.Students.AddRange(new List<Student>()
					{
						new Student(){Name="Muhammad Bilal",RollNo="BCSF20M001",Email="bcsf20m001@pucit.edu.pk",Gender="Male",DOB=new DateTime(2011, 6, 10),City="Lahore",Interest="Blogging",Department="Computer Science",DegreeTitle="Bachelors Degree",Subject="Computer",StartDate=new DateTime(2020, 6, 10),EndDate=new DateTime(2024, 6, 10)},
						new Student { Name="Arslan Adrees", RollNo="BCSF20F002", Email="arslanadrees@gmail.com", Gender="Male", DOB=new DateTime(2000, 7, 22), City="Karachi", Interest="Reading", Department="Software Engineering", DegreeTitle="M.Phil Degree", Subject="Software Engineering", StartDate=new DateTime(2020, 8, 1), EndDate=new DateTime(2024, 7, 31) },
						new Student { Name="Hafiz Arslan", RollNo="BCSF20F003", Email="hafizarslan@yahoo.com", Gender="Male", DOB=new DateTime(2010, 1, 10), City="Islamabad", Interest="Music", Department="Information Technology", DegreeTitle="Post-Graduate Diploma", Subject="Information Technology", StartDate=new DateTime(2020, 5, 1), EndDate=new DateTime(2024, 4, 30) },
						new Student { Name="Ali Hassan", RollNo="BCSF20M004", Email="ali.hassan@example.com", Gender="Male", DOB=new DateTime(2010, 5, 9), City="Rawalpindi", Interest="Sports", Department="Information Technology", DegreeTitle="Doctorate", Subject="Information Technology", StartDate=new DateTime(2020, 6, 1), EndDate=new DateTime(2024, 5, 31) },
						new Student { Name="Eva Martinez", RollNo="BCSF20F005", Email="eva.martinez@example.com", Gender="Female", DOB=new DateTime(2010, 9, 18), City="Lahore", Interest="Art", Department="Computer Science", DegreeTitle="Associate Degree", Subject="Computer Science", StartDate=new DateTime(2020, 1, 1), EndDate=new DateTime(2024, 12, 31) },
						new Student { Name="Mark Williams", RollNo="BCSF20M006", Email="mark.williams@example.com", Gender="Male", DOB=new DateTime(2005, 12, 5), City="Karachi", Interest="Traveling", Department="Software Engineering", DegreeTitle="M.Phil Degree", Subject="Software Engineering", StartDate=new DateTime(2020, 8, 1), EndDate=new DateTime(2024, 7, 31) },
						new Student { Name="Lily Davis", RollNo="BCSF20F007", Email="lily.davis@example.com", Gender="Female", DOB=new DateTime(2005, 4, 30), City="Islamabad", Interest="Dancing", Department="Information Technology", DegreeTitle="Post-Graduate Diploma", Subject="Information Technology", StartDate=new DateTime(2020, 5, 1), EndDate=new DateTime(2024, 4, 30) },
						new Student { Name="Tom Harris", RollNo="BCSF20M008", Email="tom.harris@example.com", Gender="Male", DOB=new DateTime(2005, 8, 20), City="Rawalpindi", Interest="Gaming", Department="Computer Science", DegreeTitle="Doctorate", Subject="Computer Science", StartDate=new DateTime(2020, 1, 1), EndDate=new DateTime(2024, 12, 31) },
						new Student { Name="Sophia Miller", RollNo="BCSF20F009", Email="sophia.miller@example.com", Gender="Female", DOB=new DateTime(1990, 6, 12), City="Lahore", Interest="Photography", Department="Software Engineering", DegreeTitle="Associate Degree", Subject="Software Engineering", StartDate=new DateTime(2020, 9, 1), EndDate=new DateTime(2024, 8, 31) },
						new Student { Name="Ryan Lee", RollNo="BCSF20M010", Email="ryan.lee@example.com", Gender="Male", DOB=new DateTime(1990, 2, 25), City="Karachi", Interest="Reading", Department="Information Technology", DegreeTitle="M.Phil Degree", Subject="Information Technology", StartDate=new DateTime(2020, 8, 1), EndDate=new DateTime(2024, 7, 31) },
                        new Student { Name="Michael Johnson", RollNo="BCSF20M011", Email="michael.johnson@example.com", Gender="Male", DOB=new DateTime(1990, 11, 8), City="Islamabad", Interest="Sports", Department="Computer Science", DegreeTitle="Bachelors Degree", Subject="Computer Science", StartDate=new DateTime(2020, 5, 1), EndDate=new DateTime(2024, 4, 30) },
						new Student { Name="Olivia Davis", RollNo="BCSF20F012", Email="olivia.davis@example.com", Gender="Female", DOB=new DateTime(1990, 2, 14), City="Rawalpindi", Interest="Music", Department="Software Engineering", DegreeTitle="M.Phil Degree", Subject="Software Engineering", StartDate=new DateTime(2020, 7, 1), EndDate=new DateTime(2024, 6, 30) },
						new Student { Name="Daniel Taylor", RollNo="BCSF20M013", Email="daniel.taylor@example.com", Gender="Male", DOB=new DateTime(2002, 7, 3), City="Lahore", Interest="Programming", Department="Information Technology", DegreeTitle="Post-Graduate Diploma", Subject="Information Technology", StartDate=new DateTime(2020, 9, 1), EndDate=new DateTime(2024, 8, 31) },
						new Student { Name="Sophie Harris", RollNo="BCSF20F014", Email="sophie.harris@example.com", Gender="Female", DOB=new DateTime(2002, 5, 20), City="Karachi", Interest="Dancing", Department="Computer Science", DegreeTitle="Doctorate", Subject="Computer Science", StartDate=new DateTime(2018, 1, 1), EndDate=new DateTime(2022, 12, 31) },
						new Student { Name="Henry Brown", RollNo="BCSF20M015", Email="henry.brown@example.com", Gender="Male", DOB=new DateTime(2002, 9, 28), City="Islamabad", Interest="Traveling", Department="Software Engineering", DegreeTitle="Associate Degree", Subject="Software Engineering", StartDate=new DateTime(2015, 8, 1), EndDate=new DateTime(2019, 7, 31) },
						new Student { Name="Amelia Wilson", RollNo="BCSF20F016", Email="amelia.wilson@example.com", Gender="Female", DOB=new DateTime(2002, 12, 12), City="Lahore", Interest="Photography", Department="Information Technology", DegreeTitle="M.Phil Degree", Subject="Information Technology", StartDate=new DateTime(2017, 6, 1), EndDate=new DateTime(2021, 5, 31) },
                        new Student { Name="James Smith", RollNo="BCSF20M017", Email="james.smith@example.com", Gender="Male", DOB=new DateTime(1998, 4, 5), City="Rawalpindi", Interest="Gaming", Department="Computer Science", DegreeTitle="Post-Graduate Diploma", Subject="Computer Science", StartDate=newStartDate, EndDate=newStartDate.AddYears(4).AddMonths(2).AddDays(9) },
						new Student { Name="Ella Anderson", RollNo="BCSF20F018", Email="ella.anderson@example.com", Gender="Female", DOB=new DateTime(2002, 8, 18), City="Karachi", Interest="Reading", Department="Software Engineering", DegreeTitle="Doctorate", Subject="Software Engineering", StartDate=newStartDate, EndDate=newStartDate.AddYears(4).AddMonths(6).AddDays(10) },
						new Student { Name="William Moore", RollNo="BCSF20M019", Email="william.moore@example.com", Gender="Male", DOB=new DateTime(1997, 1, 30), City="Islamabad", Interest="Art", Department="Information Technology", DegreeTitle="Bachelors Degree", Subject="Information Technology", StartDate=newStartDate, EndDate=newStartDate.AddYears(4).AddDays(11) },
						new Student { Name="Chloe Taylor", RollNo="BCSF20F020", Email="chloe.taylor@example.com", Gender="Female", DOB=new DateTime(2002, 5, 22), City="Lahore", Interest="Sports", Department="Computer Science", DegreeTitle="M.Phil Degree", Subject="Computer Science", StartDate=newStartDate, EndDate=newStartDate.AddYears(4).AddMonths(8).AddDays(11) },
						new Student { Name="Liam Johnson", RollNo="BCSF20M021", Email="liam.johnson@example.com", Gender="Male", DOB=new DateTime(1980, 10, 5), City="Islamabad", Interest="Music", Department="Software Engineering", DegreeTitle="Post-Graduate Diploma", Subject="Software Engineering", StartDate=newStartDate, EndDate=newStartDate.AddYears(-4).AddMonths(1).AddDays(11) },
                        new Student { Name="Mia Davis", RollNo="BCSF20F022", Email="mia.davis@example.com", Gender="Female", DOB=new DateTime(1995, 3, 18), City="Rawalpindi", Interest="Reading", Department="Information Technology", DegreeTitle="Doctorate", Subject="Information Technology", StartDate=new DateTime(2016, 6, 1), EndDate=new DateTime(2020, 5, 31) },
						new Student { Name="Jackson Taylor", RollNo="BCSF20M023", Email="jackson.taylor@example.com", Gender="Male", DOB=new DateTime(1993, 8, 20), City="Lahore", Interest="Gaming", Department="Computer Science", DegreeTitle="Associate Degree", Subject="Computer Science", StartDate=new DateTime(2014, 11, 1), EndDate=new DateTime(2018, 10, 31) },
						new Student { Name="Ava Harris", RollNo="BCSF20F024", Email="ava.harris@example.com", Gender="Female", DOB=new DateTime(1980, 4, 12), City="Karachi", Interest="Traveling", Department="Software Engineering", DegreeTitle="M.Phil Degree", Subject="Software Engineering", StartDate=new DateTime(2018, 9, 1), EndDate=new DateTime(2022, 8, 31) },
						new Student { Name="Ethan Wilson", RollNo="BCSF20M025", Email="ethan.wilson@example.com", Gender="Male", DOB=new DateTime(1994, 10, 28), City="Islamabad", Interest="Photography", Department="Information Technology", DegreeTitle="Post-Graduate Diploma", Subject="Information Technology", StartDate=new DateTime(2015, 12, 1), EndDate=new DateTime(2019, 11, 30) },
						new Student { Name="Emma Smith", RollNo="BCSF20F026", Email="emma.smith@example.com", Gender="Female", DOB=new DateTime(1996, 1, 15), City="Rawalpindi", Interest="Dancing", Department="Computer Science", DegreeTitle="Doctorate", Subject="Computer Science", StartDate=new DateTime(2017, 4, 1), EndDate=new DateTime(2021, 3, 31) },
						new Student { Name="Lucas Anderson", RollNo="BCSF20M027", Email="lucas.anderson@example.com", Gender="Male", DOB=new DateTime(1980, 5, 9), City="Lahore", Interest="Programming", Department="Software Engineering", DegreeTitle="Bachelors Degree", Subject="Software Engineering", StartDate=new DateTime(2019, 8, 1), EndDate=new DateTime(2023, 7, 31) },
						new Student { Name="Isabella Brown", RollNo="BCSF20F028", Email="isabella.brown@example.com", Gender="Female", DOB=new DateTime(1995, 9, 22), City="Karachi", Interest="Art", Department="Information Technology", DegreeTitle="M.Phil Degree", Subject="Information Technology", StartDate=new DateTime(2016, 11, 1), EndDate=new DateTime(2020, 10, 31) },
						new Student { Name="Mason Moore", RollNo="BCSF20M029", Email="mason.moore@example.com", Gender="Male", DOB=new DateTime(1997, 2, 28), City="Islamabad", Interest="Sports", Department="Computer Science", DegreeTitle="Associate Degree", Subject="Computer Science", StartDate=new DateTime(2018, 5, 1), EndDate=new DateTime(2019, 4, 30) },
						new Student { Name="Olivia Wilson", RollNo="BCSF20F030", Email="olivia.wilson@example.com", Gender="Female", DOB=new DateTime(1980, 6, 20), City="Rawalpindi", Interest="Reading", Department="Software Engineering", DegreeTitle="Doctorate", Subject="Software Engineering", StartDate=new DateTime(2015, 7, 1), EndDate=new DateTime(2019, 6, 30) },
                        new Student { Name="Sophie Turner", RollNo="BCSF20F031", Email="sophie.turner@example.com", Gender="Female", DOB=new DateTime(1995, 11, 6), City="Lahore", Interest="Acting", Department="Computer Science", DegreeTitle="Bachelors Degree", Subject="Computer Science", StartDate=new DateTime(2016, 12, 1), EndDate=new DateTime(2020, 11, 30) },
						new Student { Name="Alexander Reed", RollNo="BCSF20M032", Email="alexander.reed@example.com", Gender="Male", DOB=new DateTime(1998, 3, 15), City="Karachi", Interest="Writing", Department="Software Engineering", DegreeTitle="M.Phil Degree", Subject="Software Engineering", StartDate=new DateTime(2017, 7, 1), EndDate=new DateTime(2021, 6, 30) },
						new Student { Name="Grace Wilson", RollNo="BCSF20F033", Email="grace.wilson@example.com", Gender="Female", DOB=new DateTime(1994, 8, 22), City="Islamabad", Interest="Cooking", Department="Information Technology", DegreeTitle="Post-Graduate Diploma", Subject="Information Technology", StartDate=new DateTime(2015, 9, 1), EndDate=new DateTime(2019, 8, 31) },
						new Student { Name="Henry Parker", RollNo="BCSF20M034", Email="henry.parker@example.com", Gender="Male", DOB=new DateTime(1997, 1, 30), City="Rawalpindi", Interest="Photography", Department="Information Technology", DegreeTitle="Doctorate", Subject="Information Technology", StartDate=new DateTime(2018, 2, 1), EndDate=new DateTime(2022, 1, 31) },
						new Student { Name="Ava Richardson", RollNo="BCSF20F035", Email="ava.richardson@example.com", Gender="Female", DOB=new DateTime(1996, 5, 12), City="Lahore", Interest="Gardening", Department="Computer Science", DegreeTitle="Bachelors Degree", Subject="Computer Science", StartDate=new DateTime(2017, 6, 1), EndDate=new DateTime(2021, 5, 31) },
						new Student { Name="Benjamin Turner", RollNo="BCSF20M036", Email="benjamin.turner@example.com", Gender="Male", DOB=new DateTime(1993, 9, 18), City="Karachi", Interest="Music", Department="Software Engineering", DegreeTitle="M.Phil Degree", Subject="Software Engineering", StartDate=new DateTime(2014, 11, 1), EndDate=new DateTime(2018, 10, 31) },
						new Student { Name="Emma White", RollNo="BCSF20F037", Email="emma.white@example.com", Gender="Female", DOB=new DateTime(1995, 2, 10), City="Islamabad", Interest="Painting", Department="Information Technology", DegreeTitle="Post-Graduate Diploma", Subject="Information Technology", StartDate=new DateTime(2016, 4, 1), EndDate=new DateTime(2020, 3, 31) },
						new Student { Name="William Harris", RollNo="BCSF20M038", Email="william.harris@example.com", Gender="Male", DOB=new DateTime(1998, 6, 25), City="Rawalpindi", Interest="Sports", Department="Computer Science", DegreeTitle="Doctorate", Subject="Computer Science", StartDate=new DateTime(2019, 8, 1), EndDate=new DateTime(2023, 7, 31) },
						new Student { Name="Ella Martinez", RollNo="BCSF20F039", Email="ella.martinez@example.com", Gender="Female", DOB=new DateTime(1986, 11, 8), City="Lahore", Interest="Traveling", Department="Software Engineering", DegreeTitle="Bachelors Degree", Subject="Software Engineering", StartDate=new DateTime(2015, 10, 1), EndDate=new DateTime(2019, 9, 30) },
						new Student { Name="James Miller", RollNo="BCSF20M040", Email="james.miller@example.com", Gender="Male", DOB=new DateTime(1986, 4, 5), City="Karachi", Interest="Dancing", Department="Information Technology", DegreeTitle="M.Phil Degree", Subject="Information Technology", StartDate=new DateTime(2018, 9, 1), EndDate=new DateTime(2022,9,25) }
                    });
					context.ActionsLogger.AddRange(new List<ActionLogger>()
					{
						new ActionLogger{ActionDateTime=currentDate, ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-1), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-2), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-3), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-4), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-5), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-6), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-7), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-8), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-9), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-11), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-12), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-13), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-14), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-15), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-16), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-17), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-18), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-20), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-21), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-22), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-23), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-24), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-25), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-26), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-27), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-28), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-29), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-30), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-2), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-4), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-6), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-8), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-1), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-10), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-15), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-19), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-25), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-30), ActionDetail="Student added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-28), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-29), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-30), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-2), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-4), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-6), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-8), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-1), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-10), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-15), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-19), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-25), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddDays(-30), ActionDetail="Students added successfully"},

                        new ActionLogger{ActionDateTime=currentDate.AddHours(-1), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-2), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-3), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-4), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-5), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-6), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-7), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-8), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-9), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-10), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-13), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-14), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-15), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-16), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-17), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-18), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-19), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-20), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-21), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-22), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-23), ActionDetail="Students added successfully"},
                        new ActionLogger{ActionDateTime=currentDate.AddHours(-24), ActionDetail="Students added successfully"},

                    });
					context.SaveChanges();
				}

			}
		}
	}
}

