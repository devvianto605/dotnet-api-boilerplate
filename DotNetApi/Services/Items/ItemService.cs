using DotNetApi.Models;

namespace DotNetApi.Services.Items;

public class ItemService : IItemService
{
    //! Declaration: Store objects in memory
    private static readonly Dictionary<Guid, Item> _item = [];
    // OR
    // private static readonly Dictionary<Guid, Item> item = new();

    public void CreateItem(Item item)
    {
        _item.Add(item.Id, item);
    }

    public Item GetItem(Guid id)
    {
        return _item[id];
    }

    public Dictionary<Guid, Item> GetAllItem()
    {
        return _item;
    }

    public void UpsertItem(Item item)
    {
        _item[item.Id] = item;
    }
    public void DeleteItem(Guid id)
    {
        _item.Remove(id);
    }

}