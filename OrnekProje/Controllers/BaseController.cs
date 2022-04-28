using OrnekProje.CustomFilter;
using OrnekProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrnekProje.Controllers
{
    [LoginFilter]
    public class BaseController : Controller
    {
       public BaseController()
        {
            OrnekProjeEntities db = new OrnekProjeEntities();

            ViewData["TempQuestion"] = db.TempQuestion.ToList();
        }

    }
}