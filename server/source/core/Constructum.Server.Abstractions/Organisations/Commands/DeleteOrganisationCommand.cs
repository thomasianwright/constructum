using System.Text.Json.Serialization;
using FluentResults;
using Mediator;

namespace Constructum.Server.Organisations.Commands;

[method: JsonConstructor]
public class DeleteOrganisationCommand(Guid id) : ICommand<Result>
{
    public Guid Id => id;
}