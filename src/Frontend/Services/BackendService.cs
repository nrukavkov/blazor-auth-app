using System.Net.Http.Json;
using Shared.Models;

namespace Frontend.Services;

public class BackendService : IDisposable {
    private readonly HttpClient _httpClient;

    public BackendService(RenewBackendUrlHandler renewBackendUrlHandler) {
        _httpClient = new HttpClient(renewBackendUrlHandler) { BaseAddress = new Uri("https://lhr.life") };
    }

    public async Task<DateTimeOffset> GetApplicationStartDate() {
        var appInfo = await _httpClient.GetFromJsonAsync<ApplicationInfoDto>("");

        return appInfo!.ApplicationStartDate;
    }

    public async Task<string> GetMetrics() {
        return await _httpClient.GetStringAsync("metrics");
    }

    public void Dispose() {
        _httpClient.Dispose();
    }
}