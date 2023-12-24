using Application.Common.Models.RcVaultGate;

namespace Application.Common.Interfaces.RcVaultGate;

public interface IRcVaultProxy
{
	public Task<List<TimeEntry>> ProcessGetTimeEntries(string apiUrl, string timeEntriesEndpoint, string timeEntriesAuthorizationCode);
}