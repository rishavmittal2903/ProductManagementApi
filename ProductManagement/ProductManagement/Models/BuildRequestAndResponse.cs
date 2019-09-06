using ProductManagement.Entities;
using ProductManagement.Interfaces;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Models
{
    public class BuildRequestAndResponse : DelegatingHandler
    {
        private IDBContext sqlDBContext;
        public BuildRequestAndResponse()
        {
            sqlDBContext = SqlDBContext.DBInstance;
        }
        
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var logMetadata = BuildRequestMetadata(request);
            var response = await base.SendAsync(request, cancellationToken);
            logMetadata = BuildResponseMetadata(logMetadata, response);
             await sqlDBContext.SendLogData(logMetadata);
            return response;
        }
        private LogMetadata BuildRequestMetadata(HttpRequestMessage request)
        {
            LogMetadata log = new LogMetadata
            {
                RequestMethod = request.Method.Method,
                RequestTimestamp = DateTime.UtcNow.ToLongTimeString(),
                RequestUri = request.RequestUri.ToString()
            };
            return log;
        }
        private LogMetadata BuildResponseMetadata(LogMetadata logMetadata, HttpResponseMessage response)
        {
            logMetadata.ResponseStatusCode =(int) response.StatusCode;
            logMetadata.ResponseTimestamp = DateTime.UtcNow.ToLongTimeString();
            logMetadata.ResponseContentType = response.Content.Headers.ContentType.MediaType;
            return logMetadata;
        }
    }
}