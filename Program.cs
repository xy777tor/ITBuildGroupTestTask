using System.Web;

internal class Program
{
    static HttpClient client = new HttpClient();
    const string TronScanApiUri = "https://apilist.tronscanapi.com";
    const string TransactionsSecurityEndpoint = "api/security/transaction/data";
    const string TransactionHash = "853793d552635f533aa982b92b35b00e63a1c1add062c099da2450a15119bcb2";

    static async Task Main()
    {
        client.BaseAddress = new Uri(TronScanApiUri);

        var query = HttpUtility.ParseQueryString(string.Empty);
        query["hashes"] = TransactionHash;

        try
        {
            var response = await client.GetAsync($"{TransactionsSecurityEndpoint}?{query}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Ответ от API: {content}");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Ошибка при запросе к API: {ex.Message}");
        }
    }
}