using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetEmployeesChartData
{
	public class GetEmployeesChartDataDto
	{
		public string? EmployeeName { get; set; }
		public double? WorkDurationPercentage { get; set; }
	}
}
