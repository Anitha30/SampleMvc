using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer
{
    public class FriendEntityContext : IFriendEntityContext
    {
        //FriendListEntities dbContext = new FriendListEntities();
        public static FriendListEntities dbContext = null;
        private static readonly object padlock = new object();
        public static FriendListEntities DbContext
        {
            get
            {
                if (dbContext == null)
                {
                    lock (padlock)
                    {
                        if (dbContext == null)
                        {
                            dbContext = new FriendListEntities();
                        }
                    }
                }
                return dbContext;
            }
        }


        public FriendEntityContext()
        {
        }
        public void AddFriend(Friend entity)
        {
            DbContext.Friends.Add(entity);
            DbContext.SaveChanges();
        }

        public void DeleteFriend(Friend entity)
        {
            DbContext.Friends.Remove(entity);
            DbContext.SaveChanges();

        }

        public Friend GetFriendById(int id)
        {
            return DbContext.Friends.Find(id);
        }

        public IEnumerable<Friend> GetFriends()
        {
            return DbContext.Friends.ToList();
        }

        public void UpdateFriend(Friend entity)
        {
            ////DbContext.Entry(entity).State = EntityState.Modified;
            //DbContext.Entry(entity).CurrentValues.SetValues(entity);
            //DbContext.SaveChanges();

            var entityInDb = DbContext.Friends.Find(entity.FriendId);

            if (entityInDb == null)
            {
                AddFriend(entity);
                return;
            }

            DbContext.Entry(entityInDb).CurrentValues.SetValues(entity);
            DbContext.Entry(entityInDb).State = EntityState.Modified;

        }
    }
}
