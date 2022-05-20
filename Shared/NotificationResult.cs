using System.Collections.Generic;

namespace omie_api_integration.Shared
{
    public record NotificationResult
    {
        public string Message { get; private set; }
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
        public NotificationResult AddMessage(string message)
        {
            Message = message;
            return this;
        }
        public NotificationResult ShowObject(object showObject)
        {
            Object = showObject;
            return this;
        }
    }
}