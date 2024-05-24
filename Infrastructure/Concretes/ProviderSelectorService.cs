using Application.Abstracts;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Concretes;

public class ProviderSelectorService : IProviderSelectorService
{
    private readonly IEnumerable<IProviderSelector> _smsProviderSelectors;
    private readonly string _selector;

    public ProviderSelectorService(IConfiguration configuration,
                                   IEnumerable<IProviderSelector> smsProviderSelectors)
    {
        _smsProviderSelectors = smsProviderSelectors;

        _selector = configuration["Section"];
    }

    public IProviderSelector GetProviderSelectorAsync(string typeName)
    {
        switch (typeName)
        {
            case "RandomProviderSelector":
                return _smsProviderSelectors.FirstOrDefault(x => x.GetType().Name == "RandomProviderSelector");
            case "PercentProviderSelector":
                return _smsProviderSelectors.FirstOrDefault(x => x.GetType().Name == "PercentProviderSelector");

            default:
                throw new Exception("ProviderSelector is not provided");
        }
    }
}
