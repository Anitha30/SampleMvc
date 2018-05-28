using DataLayer;
using MvcFriendApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcFriendApplication.Controllers
{
    public class FriendApiController : ApiController
    {
        IFriendEntityContext _dbContext;
        IAutoMapper _mapper;
        public FriendApiController(IFriendEntityContext context, IAutoMapper mapper)
        {

            _dbContext = context;
            _mapper = mapper;
        }
        public FriendApiController()
        {

        }

        // GET api/<controller>
        public IEnumerable<FriendModel> Get()
        {
            var friends = _dbContext.GetFriends();
            var entity = _mapper.Map<Friend, FriendModel>(friends);
            return entity;
        }

        // GET api/<controller>/5
        public FriendModel Get(int id)
        {
            var entity = _dbContext.GetFriendById(id);
            var model = _mapper.Map<Friend, FriendModel>(entity);
            return model;
        }

        [HttpPost]// POST api/<controller>
        public void Post([FromBody]FriendModel model)
        {
            var entity = _mapper.Map<FriendModel, Friend>(model);

            _dbContext.UpdateFriend(entity);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var entity = _dbContext.GetFriendById(id);
            _dbContext.DeleteFriend(entity);
        }
    }
}