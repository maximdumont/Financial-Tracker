using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity.InterceptionExtension;
using Prism.Logging;
using Service.Global.Logging;

namespace Service.Global.Interceptors.Logging
{
    public class LoggingInterceptor : ILoggingInterceptor
    {
        private readonly IFinancialTrackerLogger _logger;

        public LoggingInterceptor(IFinancialTrackerLogger logger)
        {
            _logger = logger;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var result = getNext()(input, getNext);
            if (result.Exception != null)
            {
                _logger.Log(result.Exception.Message, Category.Exception, Priority.High);
            }
            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute => true;
    }
}