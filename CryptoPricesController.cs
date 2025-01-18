using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class CryptoPricesController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public CryptoPricesController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CryptoPrice>>> GetPrices()
    {
        var url = "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin,ethereum,zcash&vs_currencies=usd";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return StatusCode((int)response.StatusCode, "Error fetching cryptocurrency prices.");

        var json = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, decimal>>>(json);

        var prices = new List<CryptoPrice>
        {
            new CryptoPrice { Name = "Bitcoin", Symbol = "BTC", PriceUSD = data["bitcoin"]["usd"] },
            new CryptoPrice { Name = "Ethereum", Symbol = "ETH", PriceUSD = data["ethereum"]["usd"] },
            new CryptoPrice { Name = "Zcash", Symbol = "ZEC", PriceUSD = data["zcash"]["usd"] }
        };

        return Ok(prices);
    }
}
