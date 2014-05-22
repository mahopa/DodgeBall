using DodgeBall.Data;
using DodgeBall.DataModels;
using DodgeBall.Web.Adapters.DataAdapters;
using DodgeBall.Web.Adapters.Interfaces;
using DodgeBall.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DodgeBall.Web.Controllers
{
    public class HomeController : Controller
    {
        private IDodgeBallAdapter _adapter;

        public HomeController()
        {
            _adapter = new DodgeBallAdapter();
        }
        //Testing Constructor
        public HomeController(IDodgeBallAdapter adapter)
        {
            _adapter = adapter;
        }

        public ActionResult Index()
        {
            List<Team> teams = _adapter.GetAllTeams();
            return View(teams);
        }

        public ActionResult Team(int id)
        {
            Team team = _adapter.GetTeam(id);
            return View(team);
        }
        [HttpGet]
        public ActionResult NewTeam()
        {
            AddEditVM model = new AddEditVM();
            model.Team = new Team();
            model.Title = "Sign Up Yout Team!";
            model.ButtonMessage = "Sign Up!";
            return View(model);
        }
        [HttpPost]
        public ActionResult NewTeam(Team team)
        {
            _adapter.AddTeam(team);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditTeam(int id)
        {
            AddEditVM model = new AddEditVM();

            //Finds team that is about to be edited
            model.Team = _adapter.GetTeam(id);


            model.Title = "Edit Team " + model.Team.Name;
            model.ButtonMessage = "Submit Changes";
            return View("NewTeam",model);
        }
        [HttpPost]
        public ActionResult EditTeam(Team team)
        {
            _adapter.EditTeam(team);

           return  RedirectToAction("Team", new {id = team.Id});
        }
        [HttpPost]
        public ActionResult DeleteTeam(int id)
        {
            _adapter.DeleteTeam(id);

            return RedirectToAction("Index");
        }

    }
}