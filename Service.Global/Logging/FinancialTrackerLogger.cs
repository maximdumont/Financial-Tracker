using System;
using log4net;
using Prism.Logging;

namespace Service.Global.Logging
{
    public class FinancialTrackerLogger : IFinancialTrackerLogger
    {
        private readonly ILog _financialTrackLogger = LogManager.GetLogger(typeof(FinancialTrackerLogger));

        public void Log(string message, Category category, Priority priority)
        {
            switch (category)
            {
                case Category.Debug:
                    _financialTrackLogger.Debug(message);
                    break;
                case Category.Exception:
                    _financialTrackLogger.Error(message);
                    break;
                case Category.Info:
                    _financialTrackLogger.Info(message);
                    break;
                case Category.Warn:
                    _financialTrackLogger.Warn(message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
        }
    }
}