using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAO;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            TestCodeDao dao = new TestCodeDao();
            CustomerViewModel model = new CustomerViewModel();
            try
            {
                model.Customers = dao.GetAllCustomers();
            }
            catch (Exception ex)
            {

            }
            return View(model);
        }
        
        [HttpPost]
        public string Index(Customer data)
        {
            TestCodeDao dao = new TestCodeDao();
            string result = "";
            try
            {
                result = dao.InsertCustomer(data);
            }
            catch (Exception ex)
            {

            }
            return "SUCCESS";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}