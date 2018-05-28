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
        public int AddFriend(Friend entity)
        {
            DbContext.Friends.Add(entity);
            return DbContext.SaveChanges();
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

        public int UpdateFriend(Friend entity)
        {
            var entityInDb = DbContext.Friends.Find(entity.FriendId);

            if (entityInDb == null)
            {
                return AddFriend(entity);
            }

            DbContext.Entry(entityInDb).CurrentValues.SetValues(entity);
            DbContext.Entry(entityInDb).State = EntityState.Modified;
            return DbContext.SaveChanges();

        }
    }
}
