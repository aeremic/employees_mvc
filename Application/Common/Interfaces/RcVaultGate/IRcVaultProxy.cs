using Application.Common.Models.RcVaultGate;

namespace Application.Common.Interfaces.RcVaultGate;

public interface IRcVaultProxy
{
	/// <summary>
	/// Method for processing GetTimeEntries request.
	/// </summary>
	/// <param name="apiUrl">Base url that will be used.</param>
	/// <param name="timeEntriesEndpoint">Request endpoint.</param>
	/// <param name="timeEntriesAuthorizationCode">Needed authorization code.</param>
	/// <returns>List of time entries.</returns>
	public Task<List<TimeEntry>> ProcessGetTimeEntries(string apiUrl, string timeEntriesEndpoint, string timeEntriesAuthorizationCode);
}