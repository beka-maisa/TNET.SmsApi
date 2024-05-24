//using Application.Abstracts;

//namespace Infrastructure.Concretes;

//public class PercentProviderSelector : IProviderSelector
//{
//    private readonly List<ISmsProvider> _smsProviders;
//    private readonly Dictionary<ISmsProvider, int> _providerWeights;
//    private readonly Random _random;

//    public PercentProviderSelector(IEnumerable<ISmsProvider> smsProviders, Dictionary<ISmsProvider, int> providerWeights)
//    {
//        _smsProviders = smsProviders.ToList();
//        _providerWeights = providerWeights;
//        _random = new Random();
//    }

//    public ISmsProvider SelectProvider()
//    {
//        int totalWeight = _providerWeights.Values.Sum();
//        int randomValue = _random.Next(totalWeight);
//        int cumulativeWeight = 0;

//        foreach (var provider in _providerWeights)
//        {
//            cumulativeWeight += provider.Value;
//            if (randomValue < cumulativeWeight)
//            {
//                return provider.Key;
//            }
//        }

//        return _smsProviders.Last();
//    }
//}
