using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishAPI.Infrastructure.Messaging.Helpers
{
		public class MessageCreationResult: GenericResult
		{
				public IMessage Message { get; set; }
				public MessageCreationResult(bool success, string resultMessgae, IMessage message)
				{
						Success = success;
						ResultMessage = resultMessgae;
						Message = message;
				}
		}
}
