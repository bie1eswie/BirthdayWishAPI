using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishAPI.Models
{
		[Serializable]
		public class Employee
		{
				public int id { get; set; }
				public string name { get; set; }
				public string lastname { get; set; }
				public DateTime dateOfBirth { get; set; }
				public DateTime employmentStartDate { get; set; }
				public DateTime? employmentEndDate { get; set; }
				public string lastNotification { get; set; }
		}
}


