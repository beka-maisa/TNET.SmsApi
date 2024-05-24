using Newtonsoft.Json;

namespace Application.Requests;

public sealed class SmsRequest
{
    [JsonProperty(PropertyName = "phone")]
    public string Phone { get; set; }

    [JsonProperty(PropertyName = "text")]
    public string Text { get; set; }
}
