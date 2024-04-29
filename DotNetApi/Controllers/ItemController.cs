using DotNetApi.Contracts.Item;
using DotNetApi.Models;
using DotNetApi.Services.Items;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController(IItemService itemService) : ControllerBase
{

    // ! Dependency injection: Store object in memory
    // Primary constructor
    private readonly IItemService _itemService = itemService;

    // Non-primary constructor
    // private readonly IItemService _itemService;
    // public ItemController(IItemService itemService)
    // {
    //     _itemService = itemService;
    // }

    [HttpPost()]
    public IActionResult CreateItem(CreateItemRequest request)
    {
        // Inbound
        var item = new Item(
            id: Guid.NewGuid(),
            name: request.Name,
            description: request.Description,
            lastModifiedDateTime: DateTime.UtcNow,
            parts: request.Parts);

        _itemService.CreateItem(item);

        // TODO: Add data to database

        // Outbound
        var response = new ItemResponse(
            Id: item.Id,
            Name: item.Name,
            Description: item.Description,
            LastModifiedDateTime: item.LastModifiedDateTime,
            parts: item.Parts);

        return CreatedAtAction(
            actionName: nameof(GetItem),
            routeValues: new { id = item.Id },
            value: response);
    }

    [HttpGet()]
    public IActionResult GetAllItem()
    {
        Dictionary<Guid, Item> item = _itemService.GetAllItem();

        var response = new Dictionary<Guid, Item>(item); // TODO: Better handle as generic response

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetItem(Guid id)
    {
        Item item = _itemService.GetItem(id);

        var response = new ItemResponse(
          Id: item.Id,
          Name: item.Name,
          Description: item.Description,
          LastModifiedDateTime: item.LastModifiedDateTime,
          parts: item.Parts);

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertItem(Guid id, UpsertItemRequest request)
    {
        var item = new Item(id,
            name: request.Name,
            description: request.Description,
            lastModifiedDateTime: DateTime.UtcNow,
            parts: request.Parts);
        
        _itemService.UpsertItem(item);

        // TODO: Return 201 if a new breakfast is created
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteItem(Guid id)
    {
        _itemService.DeleteItem(id);

        return NoContent();
    }
}