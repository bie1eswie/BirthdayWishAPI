using BirthdayWishAPI.Controllers;
using BirthdayWishAPI.Infrastructure;
using BirthdayWishAPI.Infrastructure.Messaging;
using BirthdayWishAPI.Services.Logging;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BirthdayWish.Testing.Contollers
{
		public class BirthdayWishControllerTest
		{
				private readonly Mock<IBirthdayWishRepository> _mockRepo;
				private readonly Mock<IMessagingFactory> _messagingFactory;
				private readonly BirthdayWishController _birthdayWishController;
				private readonly Mock<ILoggerManager> _logger;

				public BirthdayWishControllerTest() 
				{
						_mockRepo = new Mock<IBirthdayWishRepository>();
						_messagingFactory = new Mock<IMessagingFactory>();
						_logger = new Mock<ILoggerManager>();
						_birthdayWishController = new BirthdayWishController(_mockRepo.Object, _logger.Object, _messagingFactory.Object);
				}

				[Fact]
				public void Send_Birthday_wishes_returns_json()
				{
						var result = _birthdayWishController.SendBirthdayWishes();
						Assert.IsType<JsonResult>(result);
				}
		}
}
