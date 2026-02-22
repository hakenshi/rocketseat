namespace FundamentosRest.Request;

public struct ProductRequest
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int Price { get; set; }
}