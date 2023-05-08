using My.Core.Abstracts;

namespace My.Shopping.List.Entities;

public abstract class Entity : IEntity
{
    public int Id { get; set; }
}
