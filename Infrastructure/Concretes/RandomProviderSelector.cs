using Application.Abstracts;

namespace Infrastructure.Concretes;

public class RandomProviderSelector : IProviderSelector
{
    private readonly List<ISmsProvider> _smsProviders;
    private readonly Random _random;

    public RandomProviderSelector(IEnumerable<ISmsProvider> smsProviders)
    {
        _smsProviders = smsProviders.ToList();
        _random = new Random();
    }

    public ISmsProvider SelectProvider()
    {
        var index = _random.Next(_smsProviders.Count);
        return _smsProviders[index];
    }
}
