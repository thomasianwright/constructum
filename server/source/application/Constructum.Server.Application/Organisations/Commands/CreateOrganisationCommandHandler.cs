using Constructum.Server.Entities;
using Constructum.Server.Organisations.Entities;
using Constructum.Server.Organisations.Repositories;
using FluentResults;
using Mediator;

namespace Constructum.Server.Organisations.Commands;

public class CreateOrganisationCommandHandler(IOrganisationRepository organisationRepository)
    : ICommandHandler<CreateOrganisationCommand, Result<IOrganisation>>
{
    public async ValueTask<Result<IOrganisation>> Handle(CreateOrganisationCommand command, CancellationToken cancellationToken)
    {
        var organisation = new Organisation(command.Name);
        
        var result = await organisationRepository.AddAsync(organisation, cancellationToken);
        
        if (result.IsFailed)
        {
            return result;
        }
        
        var saveChangesResult = await organisationRepository.SubmitChangesAsync(cancellationToken);
        
        if (saveChangesResult.IsFailed)
        {
            return saveChangesResult.ToResult();
        }
        
        return Result.Ok<IOrganisation>(organisation);
    }
}