using Constructum.Server.Entities;
using Constructum.Server.Organisations.Entities;
using Constructum.Server.Repositories;

namespace Constructum.Server.Organisations.Repositories;

public interface IReadOnlyOrganisationRepository : IReadOnlyRepository<Organisation, Guid>;
public interface IOrganisationRepository : IRepository<Organisation, Guid>, IReadOnlyOrganisationRepository;