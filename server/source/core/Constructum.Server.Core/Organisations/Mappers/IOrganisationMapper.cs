using Constructum.Server.Entities;
using Constructum.Server.Organisations.Dtos;
using Constructum.Server.Organisations.Entities;

namespace Constructum.Server.Organisations.Mappers;

public interface IOrganisationMapper
{
    OrganisationDto MapToDto(IOrganisation organisation);
}