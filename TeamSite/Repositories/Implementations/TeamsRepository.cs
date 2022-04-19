using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSite.DataBase;
using TeamSite.Models.TeamModels;
using TeamSite.Repositories.Abstractions;

namespace TeamSite.Repositories.Implementations
{
    public class TeamsRepository : ITeamsRepository
    {
        private TeamDbContext _DbContext;

        public TeamsRepository(TeamDbContext teamDbContext)
        {
            _DbContext = teamDbContext;
        }

        public IQueryable<TeamMember> GetTeam()
        {
            return _DbContext.TeamMembers;
        }

        public decimal TotalMembers()
        {
            return _DbContext.TeamMembers.Count();
        }
    }
}
