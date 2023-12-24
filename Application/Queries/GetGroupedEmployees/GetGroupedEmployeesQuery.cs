using MediatR;

namespace Application.Queries.GetGroupedEmployees;

public class GetGroupedEmployeesQuery : IRequest<List<GroupedEmployeeDto>>
{ }