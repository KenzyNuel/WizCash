using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class PaymentProcessorsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<PaymentProcessor>> GetProcessors()
    {
        var processors = new List<PaymentProcessor>
        {
            new PaymentProcessor 
            { 
                Name = "CoinPayments", 
                Description = "Supports over 2,000 cryptocurrencies, including Zcash.", 
                Website = "https://www.coinpayments.net" 
            },
            new PaymentProcessor 
            { 
                Name = "BitPay", 
                Description = "Global payment processor supporting Zcash and other cryptocurrencies.", 
                Website = "https://bitpay.com" 
            },
            new PaymentProcessor 
            { 
                Name = "CoinGate", 
                Description = "Simplifies cryptocurrency payments with Zcash support.", 
                Website = "https://www.coingate.com" 
            }
        };

        return Ok(processors);
    }
}
