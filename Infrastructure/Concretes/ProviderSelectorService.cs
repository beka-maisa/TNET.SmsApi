using Application.Abstracts;

namespace Infrastructure.Concretes;

public class ProviderSelectorService : IProviderSelectorService
{
    private readonly IEnumerable<IProviderSelector> _smsProviderSelectors;

    public ProviderSelectorService(IEnumerable<IProviderSelector> smsProviderSelectors)
    {
        _smsProviderSelectors = smsProviderSelectors;
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
