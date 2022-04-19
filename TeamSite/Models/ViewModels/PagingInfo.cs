using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamSite.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public int ItemPerPage { get; set; }
    }
}
