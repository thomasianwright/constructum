using Constructum.Server.Organisations.Dtos;
using Constructum.Server.Organisations.Mappers;
using Constructum.Server.Organisations.Repositories;
using Mediator;

namespace Constructum.Server.Organisations.Queries;

public class GetOrganisationsQueryHandler(
    IReadOnlyOrganisationRepository organisationRepository,
    IOrganisationMapper organisationMapper)
    : IQueryHandler<GetOrganisationsQuery, IEnumerable<OrganisationDto>>
{
    public async ValueTask<IEnumerable<OrganisationDto>> Handle(GetOrganisationsQuery query, CancellationToken cancellationToken)
    {
        var organisations = await organisationRepository.FindManyAsync(x=> query.Search == null || x.Name.Contains(query.Search), cancellationToken);
        
        return organisations.Select(organisationMapper.MapToDto);
    }
}