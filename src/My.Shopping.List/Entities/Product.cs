namespace My.Shopping.List.Entities;

/// <summary>
/// Classe só para exemplo de persistência sem utilizar IEntity
/// </summary>
public class Product
{
    public string Nome { get; set; } = string.Empty;
    public List<int> QualquerCoisa { get; set; } = new List<int>();
}
