using System;
<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> a460675f67b001fa7fa6d6de988f7635228650f5
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System.Drawing;
using CYJ.Models;
<<<<<<< HEAD
=======
using System.Collections.Generic;
>>>>>>> a460675f67b001fa7fa6d6de988f7635228650f5

namespace CYJ.Controllers
{
    public class GRAPHsController : Controller
    {
<<<<<<< HEAD
        //database 
        private cyjEntities db = new cyjEntities();

        // data for enrollment chart
        public ActionResult Index()
        {

            Highcharts columnChart = new Highcharts("columnchart");

            columnChart.InitChart(new Chart()
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Column,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.White),
               
=======

       

        // Database 
        private cyjEntities db = new cyjEntities();

        // Charts for Service Delivery View
        public ActionResult ServiceDelivery()
        {
           
            //ENROLLMENT CHART
            Highcharts enrollmentChart = new Highcharts("enrollmentChart");


         
            enrollmentChart.InitChart(new Chart()
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Column,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.White),

>>>>>>> a460675f67b001fa7fa6d6de988f7635228650f5
                Style = "fontWeight: 'bold', fontSize: '17px'",
                BorderColor = System.Drawing.Color.Gray,
                BorderRadius = 0,
                BorderWidth = 2

            });

<<<<<<< HEAD
            columnChart.SetTitle(new Title()
=======
            enrollmentChart.SetTitle(new Title()
>>>>>>> a460675f67b001fa7fa6d6de988f7635228650f5
            {
                Text = "ENROLLMENT"
            });

<<<<<<< HEAD
            

            object[] Q1Goal = Q1GoalsEnrollment().Cast<object>().ToArray();
            object[] Q1Actual = Q1ActualsEnrollment().Cast<object>().ToArray();
            //object[] ELA = ELAEnrollment().Cast<object>().ToArray();
            string[] Subcategories = subCat().ToArray();
         

            columnChart.SetXAxis(new XAxis()
=======

            // Create objects for X - Axis
            object[] Q1Goal = Q1GoalsEnrollment().Cast<object>().ToArray();
            object[] Q1Actual = Q1ActualsEnrollment().Cast<object>().ToArray();

            // Create objects for Y - Axis
            string[] Subcategories = subCat().ToArray();


            enrollmentChart.SetXAxis(new XAxis()
>>>>>>> a460675f67b001fa7fa6d6de988f7635228650f5
            {
                Type = AxisTypes.Category,
                Title = new XAxisTitle() { Text = "Goal vs Actual", Style = "fontWeight: 'bold', fontSize: '17px'" },
                Categories = Subcategories
            });

<<<<<<< HEAD
            columnChart.SetYAxis(new YAxis()
=======
            enrollmentChart.SetYAxis(new YAxis()
>>>>>>> a460675f67b001fa7fa6d6de988f7635228650f5
            {
                Title = new YAxisTitle()
                {
                    Text = "# Of students",
                    Style = "fontWeight: 'bold', fontSize: '17px'"
                },
                ShowFirstLabel = true,
                ShowLastLabel = true,
                Min = 0
            });

<<<<<<< HEAD
            columnChart.SetLegend(new Legend
            {
                Enabled = true,               
=======
            enrollmentChart.SetLegend(new Legend
            {
                Enabled = true,
>>>>>>> a460675f67b001fa7fa6d6de988f7635228650f5
                BorderRadius = 6,
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
            });

<<<<<<< HEAD

            columnChart.SetSeries(new Series[]
=======
           
            // Set series for quarterly goals + actuals
            enrollmentChart.SetSeries(new Series[]
>>>>>>> a460675f67b001fa7fa6d6de988f7635228650f5
            {
                new Series{

                    Name = "Q1 GOAL",
<<<<<<< HEAD
                    Data = new Data(Q1Goal)


=======
                    Data = new Data(Q1Goal),
                   Color = ColorTranslator.FromHtml("#3EC2CF")
>>>>>>> a460675f67b001fa7fa6d6de988f7635228650f5

                },

                new Series
                {
                    Name = "Q1 ACTUAL",
                    Data = new Data(Q1Actual),
<<<<<<< HEAD
                    

=======
                   Color = ColorTranslator.FromHtml("#bedde0")
>>>>>>> a460675f67b001fa7fa6d6de988f7635228650f5
                }

            }
            );

<<<<<<< HEAD
       

            return View(columnChart);
        }


       // Enrollment - Quarter 1 GOALS 
        public List<string> Q1GoalsEnrollment()
        {
            var q1enrollmentGoals = db.GOALACTUALs;
            var q1enrollmentQuery = (from y in q1enrollmentGoals
                                     where y.quarteroptionID == 1
                                   select new
                                   { 
                                    goalValue = y.goalValue,
                                   }).ToList();

            List<string> q1Goals = new List<string>();

            foreach (var t in q1enrollmentQuery)
            {
                
=======


            return View(enrollmentChart);
        }



        // Get the data for Q1 Goals
        public List<string> Q1GoalsEnrollment()
        {
            var cats = db.CATEGORies;
            var subcats = db.SUBCATEGORies;
            var goals = db.GOALACTUALs;

            var q1enrollmentQuery = (from y in goals
                                   where y.subcategoryID == 4 && y.quarteroptionID == 1
                                   join x in cats
                                   on y.categoryID equals x.categoryID
                                   join z in subcats
                                   on y.subcategoryID equals z.subcategoryID
                                   select new
                                   {
                                       goalValue = y.goalValue
                                   }).ToList();

            List<string> q1Goals = new List<string>();
        
            foreach (var t in q1enrollmentQuery)
            {

>>>>>>> a460675f67b001fa7fa6d6de988f7635228650f5
                q1Goals.Add(t.goalValue);

            }

            return q1Goals;
<<<<<<< HEAD
            
=======

>>>>>>> a460675f67b001fa7fa6d6de988f7635228650f5
        }

        // Enrollment - Quarter 1 ACTUALS
        public List<string> Q1ActualsEnrollment()
        {
<<<<<<< HEAD
            var q1enrollmentGoals = db.GOALACTUALs;
            var q1enrollmentQuery = (from y in q1enrollmentGoals
                                     where y.quarteroptionID == 1
                                     select new
                                     {
                                         actualGoal = y.actualGoal,
                                     }).ToList();
            
=======

            var cats = db.CATEGORies;
            var subcats = db.SUBCATEGORies;
            var goals = db.GOALACTUALs;

            var q1enrollmentQuery = (from y in goals
                                     where y.subcategoryID == 4 && y.quarteroptionID == 1
                                     join x in cats
                                     on y.categoryID equals x.categoryID
                                     join z in subcats
                                     on y.subcategoryID equals z.subcategoryID
                                     select new
                                     {
                                         actualGoal = y.actualGoal
                                     }).ToList();


>>>>>>> a460675f67b001fa7fa6d6de988f7635228650f5
            List<string> q1Actuals = new List<string>();

            foreach (var t in q1enrollmentQuery)
            {
<<<<<<< HEAD
                
=======

>>>>>>> a460675f67b001fa7fa6d6de988f7635228650f5
                q1Actuals.Add(t.actualGoal);

            }

            return q1Actuals;

<<<<<<< HEAD
        }

        public List<string> subCat()
        {
            var subcats = db.CATEGORies;
            var enrollmentQuery = (from y in subcats                                
                                   select new
                                   {
                                       subcatTypes = y.categoryName
=======


        }















        public List<string> subCat()
        {
            var cats = db.CATEGORies;
            var subcats = db.SUBCATEGORies;
            var goals = db.GOALACTUALs;

            var enrollmentQuery = (from y in goals
                                   where y.subcategoryID == 4
                                   join x in cats
                                   on y.categoryID equals x.categoryID
                                   join z in subcats
                                   on y.subcategoryID equals z.subcategoryID
                                   select new
                                   {
                                       subcatTypes = x.categoryName
>>>>>>> a460675f67b001fa7fa6d6de988f7635228650f5
                                   }).ToList();

            List<string> subCats = new List<string>();

            foreach (var t in enrollmentQuery)
            {

                subCats.Add(t.subcatTypes);

            }

            return subCats;
        }
<<<<<<< HEAD
    }
  
=======

        public ActionResult CorpMemberExperience()
        {
            return View();
        }

        public ActionResult ExternalAffairs()
        {
            return View();
        }

        public ActionResult OpEx()
        {
            return View();
        }

        public ActionResult RAD()
        {
            return View();
        }

        public ActionResult Revenue()
        {
            return View();
        }
>>>>>>> a460675f67b001fa7fa6d6de988f7635228650f5

    }


<<<<<<< HEAD
    
=======

}



>>>>>>> a460675f67b001fa7fa6d6de988f7635228650f5
