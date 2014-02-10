using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieTutorial.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //
        // GET: /HelloWorld/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// GETL /HelloWorld/Welcome
        /// </summary>
        /// <returns>Welcome action string</returns>

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            this.ViewBag.Msg = "Hello " + name + " !";
            this.ViewBag.NumTimes = numTimes;

            return View();
        }
	}
}