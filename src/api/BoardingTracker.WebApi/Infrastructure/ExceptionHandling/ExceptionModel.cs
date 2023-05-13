using Newtonsoft.Json;

namespace BoardingTracker.WebApi.Infrastructure.ExceptionHandling
{
    public class ExceptionModel
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
