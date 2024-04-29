namespace DotNetApi.Contracts.Item;

public record ItemResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime LastModifiedDateTime,
    List<string> parts);