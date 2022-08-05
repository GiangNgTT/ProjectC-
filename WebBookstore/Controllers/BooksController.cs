using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBookstore.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
       
        public ActionResult Index()
 {
 var iplPro = new AdminModel();
 var model = iplPro.ListAll();
 return View(model);
 }
}
}