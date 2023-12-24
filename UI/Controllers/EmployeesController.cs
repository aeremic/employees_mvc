using System.Diagnostics;
using Application.Queries.GetGroupedEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers;

public class EmployeesController : Controller
{
    private readonly ISender _sender;

    public EmployeesController(ISender sender)
    {
        _sender = sender;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _sender.Send(new GetGroupedEmployeesQuery());
        return View(result);
    }

    //public Task<IActionResult> EmployeesChartData()
    //{
    //    return View();
    //}
}