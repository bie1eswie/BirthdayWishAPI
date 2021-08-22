using BirthdayWishAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishAPI.Infrastructure.Messaging.BirthdayWishes
{
		public class BirthDayMessageCreator : MessageCreator
		{
				public override IMessage FactoryMethod()
				{
						return new BirthDayMessage();
				}
		}
}
