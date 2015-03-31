using System;
using System.Diagnostics;
using GalaSoft.MvvmLight.Messaging;
using Identinym.Shell.Messages;
using log4net.Appender;
using log4net.Core;

namespace Identinym.Shell.Utils
{
    public class Log4NetMessageAppender : AppenderSkeleton
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            try
            {
                var msg = new Log4NetMessage { Event = loggingEvent };
                Messenger.Default.Send(msg);
            }
            catch (Exception)
            {
                Debugger.Break();
            }
        }

        protected override bool IsAsSevereAsThreshold(Level level)
        {
            return true;
        }
    }
}
