using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace omie_api_integration.Shared
{
    public class NotificationResult
    {
        public List<string> Notifications { get; private set; } = new();
        public bool Success { get; private set; } = true;
        public object Object { get; private set; }

        public NotificationResult Ok()
        {
            Success = true;
            return this;
        }
        public NotificationResult Failure()
        {
            Success = false;
            return this;
        }
        public NotificationResult AddNotification(string notification)
        {
            Notifications.Add(notification);
            return this;
        }
        public NotificationResult ShowResult(object showObject, object teste = null)
        {
            Object = showObject;
            return this;
        }
    }
}