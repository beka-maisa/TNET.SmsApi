namespace Application.Abstracts;

public interface IProviderSelectorService
{
    IProviderSelector GetProviderSelectorAsync(string typeName);
}
