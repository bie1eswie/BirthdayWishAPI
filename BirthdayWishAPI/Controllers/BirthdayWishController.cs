using BirthdayWishAPI.Infrastructure;
using BirthdayWishAPI.Infrastructure.Messaging;
using BirthdayWishAPI.Infrastructure.Messaging.Helpers;
using BirthdayWishAPI.Infrastructure.Settings;
using BirthdayWishAPI.Services.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishAPI.Controllers
{
		[Route("[controller]")]
		[ApiController]

		// The controller is very specific to the Birthday Wish puerly because we are building with the microservices architecure in mind
		public class BirthdayWishController : Controller
		{
				private readonly IBirthdayWishRepository _birthdayWishRepository;
				private readonly ILoggerManager _logger;
				private readonly IMessagingFactory _messagingFactory;
				public BirthdayWishController(IBirthdayWishRepository birthdayWishRepository, ILoggerManager logger, IMessagingFactory messagingFactory)
				{
						_birthdayWishRepository = birthdayWishRepository;
						_logger = logger;
						_messagingFactory = messagingFactory;
				}
				[HttpGet]
				public async Task<IActionResult> SendBirthdayWishes()
				{
						try
						{
								var employeeModel = await _birthdayWishRepository.GetAllEmployees();
								var message = await _messagingFactory.CreateMessageAsync(new MessageParameter(employeeModel, MessageType.BirthdayWishes));
								return Json(message);
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return Json(new MessageCreationResult(false, ex.Message, null));
						}
				}
		}
}
