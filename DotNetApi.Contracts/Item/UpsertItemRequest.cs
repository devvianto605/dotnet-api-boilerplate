namespace DotNetApi.Contracts.Item;

public record UpsertItemRequest (
    string Name,
    string? Description,
    List<string> Parts
);