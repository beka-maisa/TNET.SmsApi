using Application.Abstracts;
using Application.Requests;

namespace Infrastructure.Concretes;

public class TwilioSmsProvider : ISmsProvider
{
    public async Task SendSmsAsync(SmsRequest message) => await Task.CompletedTask;
}
