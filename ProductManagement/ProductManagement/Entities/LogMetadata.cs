using System;

namespace ProductManagement.Entities
{
    public class LogMetadata
    {
        public string RequestContentType { get; set; } = "Accept/text";
        public string RequestUri { get; set; } = string.Empty;
        public string RequestMethod { get; set; } = string.Empty;
        public string RequestTimestamp { get; set; }
        public string ResponseContentType { get; set; } = string.Empty;
        public int ResponseStatusCode { get; set; } = 0;
        public string ResponseTimestamp { get; set; }
    }
}