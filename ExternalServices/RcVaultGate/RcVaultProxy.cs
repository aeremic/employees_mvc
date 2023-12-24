
using Application.Common.Interfaces.RcVaultGate;
using Application.Common.Models.RcVaultGate;
using Newtonsoft.Json;

namespace ExternalServices.RcVaultGate;

public class RcVaultProxy : IRcVaultProxy
{
	#region Public methods

	public async Task<List<TimeEntry>> ProcessGetTimeEntries(string apiUrl, string timeEntriesEndpoint, string timeEntriesAuthorizationCode)
	{
		List<TimeEntry>? result = default;

		var requestUrl = FormGetTimeEntriesUrl(apiUrl, timeEntriesEndpoint, timeEntriesAuthorizationCode);
		var responseString = await GetTimeEntriesAsync(requestUrl);

		if (!string.IsNullOrEmpty(responseString))
		{
			result = JsonConvert.DeserializeObject<List<TimeEntry>>(responseString);
		}

		return result ?? new List<TimeEntry>();
	}

	#endregion

	#region Private methods

	private static string FormGetTimeEntriesUrl(string apiUrl, string timeEntriesEndpoint, string timeEntriesAuthorizationCode)
	{
		return $"{apiUrl}{timeEntriesEndpoint}?code={timeEntriesAuthorizationCode}";
	}

	private static async Task<string> GetTimeEntriesAsync(string requestUrl)
	{
		using var client = new HttpClient();

		var response = await client.GetAsync(requestUrl);

		return await response.Content.ReadAsStringAsync();
	}

	#endregion
}