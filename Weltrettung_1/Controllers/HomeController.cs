using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Weltrettung_1.Models;
using System.Data.SqlClient;

namespace Weltrettung_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index1()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Index1(Detail d)
		{
            Speichern.Add(d);
			return View("Index2",d);
		}
		public IActionResult Index2()
		{
			return View(Speichern.numm);
		}
        public IActionResult Index10()
        {
            return View();
        }
        public IActionResult List()
        {
           
            SqlConnection conn = new SqlConnection("Server=desktop-i2nimam\\mysql;Database=Weltenretter;Trusted_Connection=True;");

            SqlCommand cmd = new SqlCommand("Select vorname,nachname, beruf from Held",conn);

            List<Held> list = new List<Held>();
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                HeldList.listx.Add
                    (
                        new Held
                        {
                            vorname = (string)dr["vorname"],
                            nachname = (string)dr["nachname"], 

                            beruf = (string)dr["beruf"],
                        }
                    );
            }

            return View(HeldList.listx);
        }
        public IActionResult Index4()
        {
            return View(HeldList.listx);
        }
        public IActionResult Agressor()
        {
            SqlConnection conn = new SqlConnection("Server=desktop-i2nimam\\mysql;Database=Weltenretter;Trusted_Connection=True;");

            SqlCommand cmd = new SqlCommand("Select * from Agressor", conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                AgressorList.listy.Add
                    (
                        new Aggressor
                        {
                            vorname = (string)dr["vorname"],
                            nachname = (string)dr["nachname"],

                            spezialitaet = (string)dr["spezialitaet"],
                        }
                    );
            }
            return View(AgressorList.listy);
        }

        public IActionResult Bedrohung()
        {
            SqlConnection conn = new SqlConnection("Server=desktop-i2nimam\\mysql;Database=Weltenretter;Trusted_Connection=True;");
            SqlCommand cmd = new SqlCommand("Select * from Bedrohung", conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                BedrohungListcs.bedrohs.Add
                    (
                        new Bedroh
                        {
                            bedroh_name = dr["name"] != DBNull.Value ? (string)dr["name"] : null,
                            existenz = dr["existent"] != DBNull.Value ? (bool)dr["existent"] : false,
                            agressor_id = dr["agressor_id"] != DBNull.Value ? (int)dr["agressor_id"] : 0,
                            held_id = dr["held_id"] != DBNull.Value ? (int)dr["held_id"] : 0,

                        }
                    );

            
                    
            }
            return View(BedrohungListcs.bedrohs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}