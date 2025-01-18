using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

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
    public async Task<IActionResult> GetPrices()
    {
        var url = "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin,ethereum,zcash&vs_currencies=usd";
        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadAsStringAsync();
            return Ok(data);
        }

        return StatusCode((int)response.StatusCode, "Error fetching cryptocurrency prices.");
    }
}
