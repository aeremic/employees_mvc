using System.Diagnostics;
using Application.Queries.GetEmployeesChartData;
using Application.Queries.GetGroupedEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers;

public class EmployeesController : Controller
{
	#region Properties

	private readonly ISender _sender;

	#endregion

	#region Constructors

	public EmployeesController(ISender sender)
	{
		_sender = sender;
	}

	#endregion

	#region Endpoints

	public async Task<IActionResult> Index()
	{
		var result = await _sender.Send(new GetGroupedEmployeesQuery());
		return View(result);
	}

	public async Task<IActionResult> EmployeesChartData()
	{
		var result = await _sender.Send(new GetEmployeesChartDataQuery());
		return View(result);
	}

	#endregion
}