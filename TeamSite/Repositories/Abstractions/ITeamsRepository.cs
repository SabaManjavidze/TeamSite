using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSite.Models.TeamModels;

namespace TeamSite.Repositories.Abstractions
{
    public interface ITeamsRepository
    {
        public IQueryable<TeamMember> GetTeam();
        public decimal TotalMembers();
    }
}
