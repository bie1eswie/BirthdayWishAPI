using BirthdayWishAPI.Infrastructure.Messaging.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishAPI.Services
{
		public interface IEmailService
		{
				Task<GenericResult> SendEmailAsync(string email, string subject, string message);
		}
}
