using BirthdayWishAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishAPI.Infrastructure
{
		public interface IBirthdayWishRepository
		{
				Task<EmployeesModel> GetAllEmployees();
		}
}
