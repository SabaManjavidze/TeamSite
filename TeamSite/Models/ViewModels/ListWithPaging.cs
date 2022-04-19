using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSite.Models.TeamModels;

namespace TeamSite.Models.ViewModels
{
    public class ListWithPaging
    {
        public IEnumerable<Product> products { get; set; }
        public IEnumerable<TeamMember> TeamMembers { get; set; }
        public TeamMember Member { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
