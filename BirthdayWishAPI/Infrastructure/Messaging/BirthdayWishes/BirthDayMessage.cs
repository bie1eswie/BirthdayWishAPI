using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayWishAPI.Infrastructure.Messaging
{
		public class BirthDayMessage : IMessage
		{
				public string Description { get; set; }
				public string SendMessage(MessageParameter messageParameter)
				{
						var filteredEmployeeList = from a in messageParameter.EmployeesModel.Employees
																			 where ((a.employmentEndDate ==null || a.employmentEndDate?.CompareTo(DateTime.Now)>0) && a.employmentStartDate.CompareTo(DateTime.Now) < 0) //&&
																						 //((a.dateOfBirth.Day.CompareTo(DateTime.Now.Day)==0) && (a.dateOfBirth.Month.CompareTo(DateTime.Now.Month) == 0)) ||
																						 //((a.dateOfBirth.Month ==2 && a.dateOfBirth.Day == 29) && (DateTime.Now.Day ==28 && DateTime.Now.Month ==2) && !DateTime.IsLeapYear(DateTime.Now.Year)) 
																			 select a;

						StringBuilder messageBuilder = new StringBuilder();
						messageBuilder.Append("Happy Birthday ");
						StringBuilder database = new StringBuilder();
						bool conProcessWishes = false;
						foreach (var employee in filteredEmployeeList)
						{
								var fileText = File.Exists(DateTime.Now.Date.ToString("MM_dd_yyyy") + "_processed.txt")? File.ReadAllText(DateTime.Now.Date.ToString("MM_dd_yyyy") + "_processed.txt").Contains("id:" + employee.id): false;
								if (!fileText)
								{
										messageBuilder.Append($"{employee.name} ,");
										database.AppendLine("id:" + employee.id);
										conProcessWishes = true;
								}
						}
						Description = conProcessWishes? messageBuilder.ToString().TrimEnd(','): "There was no employees with birthdays to send wishes for";
						File.AppendAllText(DateTime.Now.Date.ToString("MM_dd_yyyy") + "_processed.txt", database.ToString());
						return messageBuilder.ToString();
				}


		}
}
