using DotNetApi.Models;

namespace DotNetApi.Services.Items;

public interface IItemService
{
    void CreateItem(Item item);
    Item GetItem(Guid id);
    void UpsertItem(Item item);
    void DeleteItem(Guid id);
    Dictionary<Guid, Item> GetAllItem();
}