using Application.Abstracts;
using Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace TNET.SmsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SmsController : ControllerBase
{
    private readonly ISmsProvider _smsService;

    public SmsController(ISmsProvider smsService) => _smsService = smsService;

    [HttpPost("Send")]
    public async Task<IActionResult> SendSms([FromBody] SmsRequest request)
    {
        try
        {
            await _smsService.SendSmsAsync(request);
            return Ok("SMS sent successfully.");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to send SMS: {ex.Message}");
        }
    }
}
