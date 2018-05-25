using DataLayer;
using SampleMvcFriend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcFriend.Controllers
{
    public class FriendController : Controller
    {

        IFriendEntityContext entities;
        IAutoMapper _mapper;
        public FriendController(IFriendEntityContext context,IAutoMapper mapper)
        {
            
            entities = context;
            _mapper = mapper;
        }

        // GET: Friend
        public ActionResult Index()
        {
            var friends = entities.GetFriends();
            var friendsList = new List<FriendModel>();

            friendsList.AddRange(friends.Select(person =>
                                   new FriendModel
                                   {
                                       FriendID = person.FriendId,
                                       FriendName = person.FriendName,
                                       Place = person.Place
                                   }
                                         )
                                 );
            if (friendsList.Count != 0)
                return View(friendsList);
            else
                return View();
        }

        //public IEnumerable<FriendModel> GetAllFriends()
        //{
        //    List<FriendModel> models = new List<FriendModel>();

        //    models.Add(new FriendModel { FriendID = 1, FriendName = "Anitha", Place = "DSNR" });
        //    models.Add(new FriendModel { FriendID = 2, FriendName = "Sreekanth", Place = "Hyd" });
        //    models.Add(new FriendModel { FriendID = 3, FriendName = "Ishanvi", Place = "India" });

        //    return models;
        //}

        public ActionResult Create()
        {
            return View("InsertNewFriend");
        }

        [HttpPost]
        public ActionResult Create(FriendModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<FriendModel, Friend>(model);
                //Friend entity = new Friend();
                //entity.FriendId = model.FriendID;
                //entity.FriendName = model.FriendName;
                //entity.Place = model.Place;
                

                entities.AddFriend(entity);

                //dbContext.Friends.Add(entity);
                //dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int Id)
        {
            //FriendModel model = dbContext.Friends.Where<FriendModel>(friend => friend.FriendID.Equals(Id)).First();

           var entity = entities.GetFriendById(Id);
            FriendModel model = new FriendModel();
            model.FriendID = entity.FriendId;
            model.FriendName = entity.FriendName;
            model.Place = entity.Place;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection model)
        {
            int id = Convert.ToInt32(model["FriendId"]);
            string name = model["FriendName"].ToString();
            string place = model["Place"].ToString();

            //FriendModel entry = dbContext.Friends.Where<FriendModel>(friend => friend.FriendID.Equals(id)).First();
            var entity = entities.GetFriendById(id);
            if (entity != null)
            {
                entity.FriendName = name;
                entity.Place = place;

                entities.UpdateFriend(entity);
                //TryUpdateModel(entity, new string[] { "FriendName", "Place" }, model.ToValueProvider());
                //dbContext.Entry(entry).CurrentValues.SetValues()
                //dbContext.Entry(entity).State = EntityState.Modified;
                //dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            //FriendModel entry = dbContext.Friends.Where<FriendModel>(friend => friend.FriendID.Equals(Id)).First();
            var entity = entities.GetFriendById(Id);
            var model = new FriendModel
            {
                FriendID = entity.FriendId,
                FriendName = entity.FriendName,
                Place = entity.Place
            };
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteСonfirmed(int id)
        {
            //int id = Convert.ToInt32(model["FriendId"]);
            //string name = model["FriendName"].ToString();
            //string place = model["Place"].ToString();
            //FriendModel entry = dbContext.Friends.Where<FriendModel>(friend => friend.FriendID.Equals(id)).First();
            var entity = entities.GetFriendById(id);
            entities.DeleteFriend(entity);
            //dbContext.Friends.Remove(entity);
            //dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}