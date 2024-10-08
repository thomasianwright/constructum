using Constructum.Server.Entities;
using Constructum.Server.Organisations.Dtos;
using Constructum.Server.Organisations.Entities;
using Riok.Mapperly.Abstractions;

namespace Constructum.Server.Organisations.Mappers;

[Mapper]
public partial class OrganisationMapper : IOrganisationMapper
{
    public partial OrganisationDto MapToDto(IOrganisation organisation);
}