using Microsoft.AspNetCore.Mvc;

namespace Api2.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly string _baseUrl;

    public OrderController(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _baseUrl = configuration["WebApiBaseAddress"];
    }

    [HttpGet("fromApi1")]
    public async Task<string> GetFromApi1Async()
    {
        HttpClient httpClient = _clientFactory.CreateClient();

        var req = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/order/count");
        var resp = await httpClient.SendAsync(req);

        if (!resp.IsSuccessStatusCode)
            return "error";

        var responseStream = await resp.Content.ReadAsStringAsync();
        return $"from Api1 : {responseStream}";
    }
}
