using Application.Common.Interfaces.RcVaultGate;
using Application.Common.Options;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetEmployeesChartData
{
	public class GetEmployeesChartDataQueryHandler : IRequestHandler<GetEmployeesChartDataQuery, List<GetEmployeesChartDataDto>>
	{
		#region Propeties

		private readonly RcVaultOptions _options;
		private readonly IRcVaultProxy _rcVaultProxy;

		#endregion

		#region Constructors

		public GetEmployeesChartDataQueryHandler(IOptions<RcVaultOptions> options, IRcVaultProxy rcVaultProxy)
		{
			_options = options.Value;
			_rcVaultProxy = rcVaultProxy;
		}

		#endregion

		#region Methods

		public async Task<List<GetEmployeesChartDataDto>> Handle(GetEmployeesChartDataQuery request, CancellationToken cancellationToken)
		{
			var result = new List<GetEmployeesChartDataDto>();
			try
			{
				var timeEntriesResult = await _rcVaultProxy.ProcessGetTimeEntries(
					_options.ApiUrl ?? string.Empty,
					_options.GetTimeEntriesEndpoint ?? string.Empty,
					_options.GetTimeEntriesAuthorizationCode ?? string.Empty);

				if (timeEntriesResult.Any())
				{

					var workDurationSum = timeEntriesResult
						.Where(timeEntry => timeEntry.Id.HasValue && !string.IsNullOrEmpty(timeEntry.EmployeeName))
						.Sum(timeEntry => timeEntry.EndTimeUtc.HasValue && timeEntry.StarTimeUtc.HasValue
							? timeEntry.EndTimeUtc.Value.Hour - timeEntry.StarTimeUtc.Value.Hour : 0);

					result = timeEntriesResult
						.Where(timeEntry => timeEntry.Id.HasValue && !string.IsNullOrEmpty(timeEntry.EmployeeName))
						.GroupBy(timeEntry => timeEntry.EmployeeName)
						.Select(timeEntry => new
						{
							EmployeeName = timeEntry.Key,
							WorkDurationInHours = timeEntry.Sum(t => t.EndTimeUtc.HasValue && t.StarTimeUtc.HasValue
								? t.EndTimeUtc.Value.Hour - t.StarTimeUtc.Value.Hour : 0)
						})
						.Select(timeEntry => new GetEmployeesChartDataDto
						{
							EmployeeName = timeEntry.EmployeeName,
							WorkDurationPercentage = ((double)timeEntry.WorkDurationInHours / (double)workDurationSum) * 100.0
						})
						.ToList();
				}
			}
			catch (Exception ex)
			{

			}

			return result;
		}

		#endregion
	}
}
