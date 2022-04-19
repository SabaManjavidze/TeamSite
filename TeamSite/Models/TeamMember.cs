using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamSite.Models.TeamModels
{
    public class TeamMember
    {
        public string Name { get; set; }

        public int JerseyNumber { get; set; }

        public Role RoleInTeam { get; set; }

        public Position Position { get; set; }
        public int Id { get; set; }
    }

    public enum Role
    {
        Coach,
        Player
    }

    public enum Position
    {
        Forward,
        Defener,
        GoalKeeper,
        MidleField
    }
}
