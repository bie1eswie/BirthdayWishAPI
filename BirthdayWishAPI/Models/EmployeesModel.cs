using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishAPI.Models
{
		[Serializable]
		public class EmployeesModel
		{
				public List<Employee> Employees { get; set; }

				public EmployeesModel(List<Employee> employees)
				{
						Employees = employees;
				}
		}
}
