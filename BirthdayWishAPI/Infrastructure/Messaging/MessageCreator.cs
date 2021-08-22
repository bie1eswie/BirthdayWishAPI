using BirthdayWishAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishAPI.Infrastructure.Messaging
{
		public abstract class MessageCreator : IMessageCreator
		{
				public abstract IMessage FactoryMethod();
				public IMessage CreateAndSendMessage(MessageParameter messageParameter)
				{
						var message = FactoryMethod();
						message.SendMessage(messageParameter);
						return message;
				}
		}
}
