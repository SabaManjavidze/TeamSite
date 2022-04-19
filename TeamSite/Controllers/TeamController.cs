using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamSite.Models.ViewModels;
using TeamSite.Repositories.Abstractions;

namespace TeamSite.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        private readonly ITeamsRepository _teamsRepository;

        public TeamController(ITeamsRepository teamsRepository)
        {
            _teamsRepository = teamsRepository;
        }

        int PageSize = 3;
        



        public IActionResult List(int productPage = 1)
        {
            var members = _teamsRepository.GetTeam();
                                             
            ListWithPaging listWithPaging = new ListWithPaging();

            var totalItems = members.Count();

            var TotalPages = (int)Math.Ceiling((decimal)totalItems / PageSize);
            members = members.Skip((productPage - 1) * PageSize).Take(PageSize);

            var pagingInfo = new PagingInfo()
            {
                CurrentPage = productPage,
                TotalItems = totalItems,
                TotalPages = TotalPages,
                ItemPerPage = PageSize
            };

            listWithPaging.TeamMembers = members;
            listWithPaging.PagingInfo = pagingInfo;


            return View(listWithPaging);
        }
    }
}
