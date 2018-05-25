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
        //IFriendEntityContext _dbContext;
        //IAutoMapper _mapper;
        //public FriendController(IFriendEntityContext context, IAutoMapper mapper)
        //{

        //    _dbContext = context;
        //    _mapper = mapper;
        //}
        public FriendController()
        {

        }
        // GET: Friend
        public ActionResult Index()
        {
            //var friends = _dbContext.GetFriends();
            //var entity = _mapper.Map<Friend, FriendModel>(friends);
            
            //if (entity.Count() != 0)
            //    return View(entity);
            //else
                return View();
        }

        
        public ActionResult Create()
        {
            return PartialView("InsertNewFriend");
        }

        public ActionResult Test()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Create(FriendModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var entity = _mapper.Map<FriendModel, Friend>(model);
        //        _dbContext.AddFriend(entity);

        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        public ActionResult Edit(int Id)
        {
            //var entity = _dbContext.GetFriendById(Id);
            //var model = _mapper.Map<Friend, FriendModel>(entity);

            return PartialView();
        }
        /*
        [HttpPost]
        public ActionResult Edit(FormCollection model)
        {
            int id = Convert.ToInt32(model["FriendId"]);
            string name = model["FriendName"].ToString();
            string place = model["Place"].ToString();

            var entity = _dbContext.GetFriendById(id);
            if (entity != null)
            {
                entity.FriendName = name;
                entity.Place = place;

                _dbContext.UpdateFriend(entity);
            }

            return RedirectToAction("Index");
        }
        */
        public ActionResult Delete(int Id)
        {
            return PartialView();
        }
        /*
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteСonfirmed(int id)
        {
            var entity = _dbContext.GetFriendById(id);
            _dbContext.DeleteFriend(entity);

            return RedirectToAction("Index");
        } 
        #endregion */
    }
}