using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using omie_poc.Omie.Servico;

namespace omie_api_integration.Shared
{
    public class NotificationResult
    {
        public string Message { get; private set; }
        public bool Success { get; private set; } = true;
        public object Object { get; private set; }
        public OmieCriarServicoResult ServicoResult { get; private set; }

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
        public NotificationResult ShowMessage(string message)
        {
            Message = message;
            return this;
        }
        public NotificationResult ShowResult(object showObject, object teste = null)
        {
            Object = showObject;
            return this;
        }
        public NotificationResult ShowServicoResult(OmieCriarServicoResult result)
        {
            ServicoResult = result;
            return this;
        }
    }
}