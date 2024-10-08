using Constructum.Server.Organisations.Entities;

namespace Constructum.Server.Organisations.Repositories;

public class OrganisationRepository(ApplicationDbContext context) : Repository<Organisation, Guid>(context), IOrganisationRepository;