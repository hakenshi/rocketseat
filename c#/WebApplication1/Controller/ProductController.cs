using System.Net;
using FundamentosRest.Request;
using FundamentosRest.Responses;
using Microsoft.AspNetCore.Mvc;
using Product = FundamentosRest.Model.Product;

namespace FundamentosRest.Controller;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly List<Product> _products = new()
    {
        new Product
        {
            Id = 1,
            Name = "Mouse Wired Pro",
            Description = "Mouse com sensor 8K DPI e conexão USB-A.",
            Price = 129
        },
        new Product
        {
            Id = 2,
            Name = "Teclado Mecânico 75%",
            Description = "Layout 75%, switch linear e hot-swap.",
            Price = 389
        },
        new Product
        {
            Id = 3,
            Name = "Headset Stereo",
            Description = "Headset com microfone removível e conector P2/P3.",
            Price = 159
        },
        new Product
        {
            Id = 4,
            Name = "Mousepad XL",
            Description = "Mousepad 90x40cm com base emborrachada.",
            Price = 79
        },
        new Product
        {
            Id = 5,
            Name = "SSD NVMe 1TB",
            Description = "SSD NVMe de 1TB com alta velocidade de leitura.",
            Price = 349
        },
        new Product
        {
            Id = 6,
            Name = "HD Externo 2TB",
            Description = "Armazenamento portátil 2TB via USB 3.0.",
            Price = 419
        },
        new Product
        {
            Id = 7,
            Name = "Webcam 1080p",
            Description = "Webcam Full HD 1080p com microfone embutido.",
            Price = 199
        },
        new Product
        {
            Id = 8,
            Name = "Monitor 24 IPS",
            Description = "Monitor 24\" IPS Full HD com 75Hz.",
            Price = 699
        },
        new Product
        {
            Id = 9,
            Name = "Hub USB-C",
            Description = "Hub USB-C com HDMI, USB e leitor SD.",
            Price = 149
        },
        new Product
        {
            Id = 10,
            Name = "Cabo USB-C 2m",
            Description = "Cabo USB-C de 2 metros com suporte a 60W.",
            Price = 39
        }
    };

    [HttpGet]
    [ProducesResponseType(typeof(ProductResponse), 200)]
    public IActionResult Get()
    {
        return Ok(
            _products
        );
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductResponse), 200)]
    public IActionResult Get(string id, [FromHeader] string token)
    {
        var product = _products.Find(p => p.Id == int.Parse(id));
        return Ok(
            product
        );
    }

    [HttpPost]
    [ProducesResponseType(typeof(ProductResponse), 201)]
    public IActionResult Store([FromBody] ProductRequest request)
    {
        var newProduct = new Product
        {
            Description = request.Description,
            Name = request.Name,
            Price = request.Price
        };
        _products.Add(newProduct);

        return Created();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    public IActionResult Update(string id, [FromBody] ProductRequest request)
    {
        var index = _products.FindIndex(p => p.Id == int.Parse(id));
        var product = _products.Find(p => p.Id == int.Parse(id));

        var updatedProduct = index != 0 ? _products[index] : product;

        return Ok(updatedProduct);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.NotFound)]
    public IActionResult Delete(string id)
    {
        var productToDelete = _products.FindIndex(p => p.Id == int.Parse(id));

        if (productToDelete < 0) NotFound();

        _products.RemoveAt(productToDelete);
        return NoContent();
    }
}