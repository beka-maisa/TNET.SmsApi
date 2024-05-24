using Application.Requests;

namespace Application.Abstracts;

public interface ISmsProvider
{
    Task SendSmsAsync(SmsRequest message);
}
