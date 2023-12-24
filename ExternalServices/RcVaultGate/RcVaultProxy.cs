
using Application.Common.Interfaces.RcVaultGate;
using Application.Common.Models.RcVaultGate;
using Newtonsoft.Json;

namespace ExternalServices.RcVaultGate;

public class RcVaultProxy : ProxyBase, IRcVaultProxy
{
	#region Public methods

	public async Task<List<TimeEntry>> ProcessGetTimeEntries(string apiUrl, string timeEntriesEndpoint, string timeEntriesAuthorizationCode)
	{
		List<TimeEntry>? result = default;

		var requestUrl = FormGetTimeEntriesUrl(apiUrl, timeEntriesEndpoint, timeEntriesAuthorizationCode);
		var responseString = await GetAsync(requestUrl);

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

	#endregion
}