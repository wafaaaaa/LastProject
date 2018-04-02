using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System.Drawing;
using CYJ.Models;

namespace CYJ.Controllers
{
    public class GRAPHsController : Controller
    {
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
               
                Style = "fontWeight: 'bold', fontSize: '17px'",
                BorderColor = System.Drawing.Color.Gray,
                BorderRadius = 0,
                BorderWidth = 2

            });

            columnChart.SetTitle(new Title()
            {
                Text = "ENROLLMENT"
            });

            

            object[] Q1Goal = Q1GoalsEnrollment().Cast<object>().ToArray();
            object[] Q1Actual = Q1ActualsEnrollment().Cast<object>().ToArray();
            //object[] ELA = ELAEnrollment().Cast<object>().ToArray();
            string[] Subcategories = subCat().ToArray();
         

            columnChart.SetXAxis(new XAxis()
            {
                Type = AxisTypes.Category,
                Title = new XAxisTitle() { Text = "Goal vs Actual", Style = "fontWeight: 'bold', fontSize: '17px'" },
                Categories = Subcategories
            });

            columnChart.SetYAxis(new YAxis()
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

            columnChart.SetLegend(new Legend
            {
                Enabled = true,               
                BorderRadius = 6,
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
            });


            columnChart.SetSeries(new Series[]
            {
                new Series{

                    Name = "Q1 GOAL",
                    Data = new Data(Q1Goal)



                },

                new Series
                {
                    Name = "Q1 ACTUAL",
                    Data = new Data(Q1Actual),
                    

                }

            }
            );

       

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
                
                q1Goals.Add(t.goalValue);

            }

            return q1Goals;
            
        }

        // Enrollment - Quarter 1 ACTUALS
        public List<string> Q1ActualsEnrollment()
        {
            var q1enrollmentGoals = db.GOALACTUALs;
            var q1enrollmentQuery = (from y in q1enrollmentGoals
                                     where y.quarteroptionID == 1
                                     select new
                                     {
                                         actualGoal = y.actualGoal,
                                     }).ToList();
            
            List<string> q1Actuals = new List<string>();

            foreach (var t in q1enrollmentQuery)
            {
                
                q1Actuals.Add(t.actualGoal);

            }

            return q1Actuals;

        }

        public List<string> subCat()
        {
            var subcats = db.CATEGORies;
            var enrollmentQuery = (from y in subcats                                
                                   select new
                                   {
                                       subcatTypes = y.categoryName
                                   }).ToList();

            List<string> subCats = new List<string>();

            foreach (var t in enrollmentQuery)
            {

                subCats.Add(t.subcatTypes);

            }

            return subCats;
        }
    }
  

    }


    
