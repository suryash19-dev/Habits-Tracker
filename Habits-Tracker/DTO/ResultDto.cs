using System.Net;
using System.Text.Json.Serialization;

namespace Habits_Tracker.DTO
{
    public class ResultDto<T>
    {
        // Gets or sets the Is Success
        public bool IsSuccess { get; set; }

        // Gets or sets the Dynamic Model
        public T? Data { get; set; }

        // Gets or sets the Error Code
        public string? ErrorCode { get; set; }

        // Gets or sets the Error Message
        public string? ErrorMessage { get; set; }

        // Gets or sets the Status

        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}
