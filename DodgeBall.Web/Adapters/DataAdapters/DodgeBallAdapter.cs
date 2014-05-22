using DodgeBall.Data;
using DodgeBall.DataModels;
using DodgeBall.Web.Adapters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DodgeBall.Web.Adapters.DataAdapters
{
    public class DodgeBallAdapter : IDodgeBallAdapter
    {
        
        //TEAMS CRUD
        public List<DataModels.Team> GetAllTeams()
        {
            List<Team> teams = new List<Team>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                teams = db.Teams.ToList();
            }
            return teams;
        }

        public Team GetTeam(int id)
        {
            Team team = new Team();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                team = db.Teams.Include("Players").Where(x => x.Id == id).FirstOrDefault();
            }
            return team;
        }


        public void AddTeam(Team team)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Teams.Add(team);
                var sentback = db.SaveChanges();
            }
        }
        public void EditTeam(Team team)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Team model = db.Teams.Find(team.Id);
                model.Name = team.Name;
                model.Logo = team.Logo;
                db.SaveChanges();
            }
        }
        public void DeleteTeam(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Team team = db.Teams.Find(id);
                db.Teams.Remove(team);
                db.SaveChanges();
            }
        }
        //Players CRUD
    }
}