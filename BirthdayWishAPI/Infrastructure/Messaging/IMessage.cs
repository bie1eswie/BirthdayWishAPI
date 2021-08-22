using BirthdayWishAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishAPI.Infrastructure.Messaging
{
	  public	interface IMessage
		{
				public string Description { get; set; }
				string SendMessage(MessageParameter messageParameter);
		}
}
