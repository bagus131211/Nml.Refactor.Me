using System;
using System.Threading.Tasks;
using Nml.Refactor.Me.Dependencies;
using Nml.Refactor.Me.MessageBuilders;

namespace Nml.Refactor.Me.Notifiers
{
	public class SmsNotifier : BaseNotifier
	{
		private readonly IStringMessageBuilder _messageBuilder;
		private readonly IOptions _options;
		private readonly ILogger _logger = LogManager.For<SmsNotifier>();

		public SmsNotifier(IStringMessageBuilder messageBuilder, IOptions options, ILogger logger)
			: base(messageBuilder, options, logger)
		{
			_messageBuilder = messageBuilder;
			_options = options;
			_logger = logger;
		}

        public override async Task Notify(NotificationMessage message)
        {
			var smsApiClient = new SmsApiClient(_options.Sms.ApiUri, _options.Sms.ApiKey);
			var smsMessage = _messageBuilder.CreateMessage(message);
			string mobileNumber = "any generated number";
            try
            {
				await smsApiClient.SendAsync(mobileNumber, smsMessage);
				_logger.LogTrace("Sms sent.");
            }
            catch (Exception ex)
            {
				_logger.LogError(ex, $"Failed to send sms. Message : {ex.Message}");
				throw;
            }
        }
	}
}
