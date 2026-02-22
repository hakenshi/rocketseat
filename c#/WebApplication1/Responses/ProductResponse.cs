
using FundamentosRest.Model;

namespace FundamentosRest.Responses;

public struct ProductResponse
{
    public Product Product  { get; set; }
    public string Message { get; set; }
}