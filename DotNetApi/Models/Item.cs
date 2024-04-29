namespace DotNetApi.Models;

// ! Primary Constructor
public class Item(
    Guid id,
    string name,
    string? description,
    DateTime lastModifiedDateTime,
    List<string> parts)
{
    public Guid Id { get; } = id;
    public string Name { get; } = name;
    public string Description { get; } = description ?? "No Description";
    public DateTime LastModifiedDateTime { get; } = lastModifiedDateTime;
    public List<string> Parts { get; } = parts;

// ! Separated Template and Constructor
// public class Item
// {
//     public Guid Id { get; }
//     public string Name { get; }
//     public string Description { get; }
//     public DateTime LastModifiedDateTime { get; }
//     public List<string> Parts { get; }

//     public Item(
//         Guid id,
//         string name,
//         string description,
//         DateTime lastModifiedDateTime,
//         List<string> parts)
//     {
//         Id = id;
//         Name = name;
//         Description = description;
//         LastModifiedDateTime = lastModifiedDateTime;
//         Parts = parts;
//     }

}