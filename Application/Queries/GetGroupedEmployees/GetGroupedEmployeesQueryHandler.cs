using Application.Common.Interfaces.RcVaultGate;
using Application.Common.Options;
using MediatR;
using Microsoft.Extensions.Options;

namespace Application.Queries.GetGroupedEmployees;

public class GetGroupedEmployeesQueryHandler : IRequestHandler<GetGroupedEmployeesQuery, List<GroupedEmployeeDto>>
{
    #region Propeties

    private readonly RcVaultOptions _options;
    private readonly IRcVaultProxy _rcVaultProxy;

    #endregion

    #region Constructors

    public GetGroupedEmployeesQueryHandler(IOptions<RcVaultOptions> options, IRcVaultProxy rcVaultProxy)
    {
        _options = options.Value;
        _rcVaultProxy = rcVaultProxy;
    }

    #endregion

    #region Methods

    public async Task<List<GroupedEmployeeDto>> Handle(GetGroupedEmployeesQuery request, CancellationToken cancellationToken)
    {
        var result = new List<GroupedEmployeeDto>();
        try
        {
            var timeEntriesResult = await _rcVaultProxy.ProcessGetTimeEntries(
                _options.ApiUrl ?? string.Empty,
                _options.GetTimeEntriesEndpoint ?? string.Empty,
                _options.GetTimeEntriesAuthorizationCode ?? string.Empty);

            if (timeEntriesResult.Any())
            {
                result = timeEntriesResult
                    .Where(timeEntry => timeEntry.Id.HasValue && !string.IsNullOrEmpty(timeEntry.EmployeeName))
                    .GroupBy(timeEntry => timeEntry.EmployeeName)
                    .Select(timeEntry => new GroupedEmployeeDto
                    {
                        EmployeeName = timeEntry.Key,
                        WorkDurationInHours = timeEntry.Sum(t => t.EndTimeUtc.HasValue && t.StarTimeUtc.HasValue
                            ? t.EndTimeUtc.Value.Hour - t.StarTimeUtc.Value.Hour : 0)
                    }).ToList();
            }
        }
        catch (Exception ex)
        {

        }

        return result;
    }

    #endregion
}