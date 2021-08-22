using BirthdayWishAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishAPI.Infrastructure.Messaging
{
		public class MessageParameter
		{
				public EmployeesModel EmployeesModel { get; set; }

				public MessageType MessageType { get; set; }

				public MessageParameter(EmployeesModel employeesModel, MessageType messageType)
				{
						EmployeesModel = employeesModel;
						MessageType = messageType;
				}
		}
}
