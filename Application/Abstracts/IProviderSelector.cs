namespace Application.Abstracts;

public interface IProviderSelector
{
    ISmsProvider SelectProvider();
}
