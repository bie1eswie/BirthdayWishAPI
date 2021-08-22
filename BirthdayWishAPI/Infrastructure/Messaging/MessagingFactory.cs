using BirthdayWishAPI.Infrastructure.Messaging.BirthdayWishes;
using BirthdayWishAPI.Infrastructure.Messaging.Helpers;
using BirthdayWishAPI.Infrastructure.Settings;
using BirthdayWishAPI.Services;
using BirthdayWishAPI.Services.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishAPI.Infrastructure.Messaging
{
		public enum MessageType
		{
				BirthdayWishes,
				//other message types would come here
		}
		// I have went with a factory design patterns to allow for a more extensible message creation and sending.
		// It is at this point where we take care of what message to create at runtime
		public class MessagingFactory: IMessagingFactory
		{
				private readonly IEmailService _emailService;
				private readonly AppSettings _settings;
				private readonly ILoggerManager _logger;
				public MessagingFactory(IEmailService emailService, IOptions<AppSettings> settings, ILoggerManager logger)
				{
						_emailService = emailService;
						_settings = settings.Value;
						_logger = logger;
				}
				// Factory Method
				// MessageParameter encapsulates the arguments to this factory method
				public async Task<MessageCreationResult> CreateMessageAsync(MessageParameter messageParameter)
				{
						try
						{
								MessageCreationResult result;
								switch (messageParameter.MessageType)
								{
										case MessageType.BirthdayWishes:
												var message = new BirthDayMessageCreator().CreateAndSendMessage(messageParameter);

												result = new MessageCreationResult(true, "Birthday wishes send successfully", message);
												break;
										//new message case would go here

										default:
												return new MessageCreationResult(false, "Message type not found", null);
								}
								var sendEmailResult = await _emailService.SendEmailAsync(_settings.BirthdayWishesEmail, _settings.BirthdayWishesSubject, result.Message.Description);
								result.Success &= sendEmailResult.Success;
								return result;
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return new MessageCreationResult(false, ex.Message, null);
						}
				}
		}
}
