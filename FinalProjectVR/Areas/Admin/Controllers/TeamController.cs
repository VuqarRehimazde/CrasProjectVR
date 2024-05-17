﻿using BusinessLayer.Abstrsact;
using DTOLayer.TeamDTO;
using DTOLayer.TestimonialDTO;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var teamMembers = _teamService.TGetAll().Data;
            return View(teamMembers);
        }
        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTeam(TeamCreateDTOs teamDTOs,IFormFile photoUrl)
        {
            var result = _teamService.TAdd(teamDTOs, photoUrl);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult UpdateTeam(int id)
        {
            var teamMember = _teamService.TGetById(id).Data;
            return View(teamMember);
        }

        [HttpPost]
        public IActionResult UpdateTeam(TeamDTOs teamDTOs,IFormFile photoUrl)
        {
            var result = _teamService.TUpdate(teamDTOs, photoUrl);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(teamDTOs);
        }

        public IActionResult DeleteTeam(int id)
        {
            var teamMember = _teamService.TGetById(id).Data;
            _teamService.TDelete(teamMember);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult HardDeleteTeam(int id)
        {
            var teamMember = _teamService.TGetById(id).Data;
            _teamService.THardDelete(teamMember);
            return RedirectToAction("Index");
        }

    }
}
