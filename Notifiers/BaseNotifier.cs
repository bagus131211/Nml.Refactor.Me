namespace Nml.Refactor.Me.Notifiers
{
    using Dependencies;
    using MessageBuilders;
    using System;
    using System.Threading.Tasks;
    public class BaseNotifier : INotifier
    {
        readonly IMessageBuilder<object> messageBuilder;
        readonly IOptions options;
        readonly ILogger logger = LogManager.For<BaseNotifier>();

        public BaseNotifier(IMessageBuilder<object> messageBuilder, IOptions options, ILogger logger)
        {
            this.messageBuilder = messageBuilder;
            this.options = options;
            this.logger = logger;
        }

        public virtual Task Notify(NotificationMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
