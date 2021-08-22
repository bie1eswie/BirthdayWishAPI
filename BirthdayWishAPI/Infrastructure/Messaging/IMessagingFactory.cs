using BirthdayWishAPI.Infrastructure.Messaging.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishAPI.Infrastructure.Messaging
{
		public interface IMessagingFactory
		{
				Task<MessageCreationResult> CreateMessageAsync(MessageParameter messageParameter);
		}
}
