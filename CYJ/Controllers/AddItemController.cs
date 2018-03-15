using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CYJ.Models;
using CYJ.Models.ViewModels;
using CYJ.Services;
using Newtonsoft.Json;

namespace CYJ.Controllers
{
    public class AddItemController : Controller
    {
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        // reading from the db
        private readonly TeamServices _teamServices;
        private readonly WorkstreamServices _workstreamServices;
        private readonly CategoryServices _categoryServices;
        private readonly SubcategoryServices _subCategoryServices;
        private readonly GoalServices _goalServices;

        // GET: AddItem
        public AddItemController()
        {
            _teamServices = new TeamServices();
            _workstreamServices = new WorkstreamServices();
            _categoryServices = new CategoryServices();
            _subCategoryServices = new SubcategoryServices();
            _goalServices = new GoalServices();
        }
        public ActionResult Index()
        {
            return View();
        }

        public static void PopulateTeam(string query, string txt)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string constr = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@teamName", txt);
                cmd.ExecuteNonQuery();
            }
        }

        [HttpGet]
        public ActionResult NewTeam()
        {
            var model = new TeamViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult NewTeam(TeamViewModel model, string teamName)
        {
            PopulateTeam("Insert into TEAM(teamName) VALUES (@teamName)", model.teamName);
            return View();
        }
    }
}