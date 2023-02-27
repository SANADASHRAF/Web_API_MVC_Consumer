using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    // instal microsoft asp.net web api .client
    //using system.net.Http;
    

    public class HomeController : Controller
    {

       public HttpClient client=new HttpClient();


        public HomeController ( )
        {
            client.BaseAddress = new Uri("https://egypttrainapi.azurewebsites.net/api/");
        }

        ////////////////////// show
        public ActionResult  x()
        {
            //get
            var users = client.GetAsync("user/getusers").Result;
            if (users.IsSuccessStatusCode)
            {
                var x = users.Content.ReadAsAsync<List<User>>().Result;
                return View(x);
            }
            else
            {
                var r=users.StatusCode.ToString();
                return View(r);
            }
            return RedirectToAction("x");
        }

        /////////////////////////////////////post
        public ActionResult post()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult post(User use)
        {
            var user = client.PostAsJsonAsync("user/createuser", use).Result;
            if (user.IsSuccessStatusCode)
            {
                return RedirectToAction("x");
            }
            else
            {
                var x = user.StatusCode.ToString();
                ViewBag.status = x;
                return View();
            }
            return View();

        }

        ///////////////////////////////////////// update
        
        public ActionResult update(int Id)
        {
            
            var user = client.GetAsync($"user/GetUserById?Id={Id}").Result;
            if (user.IsSuccessStatusCode)
            {
                var result = user.Content.ReadAsAsync<User>().Result;
            return View(result);
            }
            return View();
        }
        [HttpPost]
        public ActionResult update(int Id, User user)
        {
            if (user.Id == Id)
            {
                var result = client.PutAsJsonAsync($"user/updateuser?userId={Id}", user).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("x");
                }
                else
                {
                    return View();
                }
            }

            else
                return View(user);

        }


        /////////////////////////////////////////////////////////////// delete

        public ActionResult delete(int Id)
        {
            var user = client.GetAsync($"user/GetUserById?Id={Id}").Result;
            var result = client.DeleteAsync($"user/deleteuser?Id={Id}").Result;
            return RedirectToAction("x");
        }
            public ActionResult Index()
        {
            return View();
        }


        
        /// ///////////////////////////////////////////////////////////////////////////////////////////
        
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