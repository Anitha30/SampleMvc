using DataLayer;
using MvcFriendApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFriendApplication.Controllers
{
    public class FriendController : Controller
    {
        public FriendController()
        {

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View("InsertNewFriend");
        }
    }
}