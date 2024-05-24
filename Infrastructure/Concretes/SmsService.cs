using Application.Abstracts;
using Application.Requests;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Concretes;

public class SmsService : ISmsProvider
{
    private readonly IProviderSelectorService _providerSelectorService;
    private readonly string _selector;

    public SmsService(IProviderSelectorService providerSelectorService, IConfiguration configuration)
    {
        _providerSelectorService = providerSelectorService;
        _selector = configuration["Selector"];
    }

    public async Task SendSmsAsync(SmsRequest message)
    {
        var providerSelector = _providerSelectorService.GetProviderSelectorAsync(_selector);

        var provider = providerSelector.SelectProvider();

        if (provider == null)
            throw new InvalidOperationException("No suitable SMS provider found.");

        // Use the selected provider to send the SMS
        await provider.SendSmsAsync(message);
    }
}
