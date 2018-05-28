using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IFriendEntityContext
    {
        IEnumerable<Friend> GetFriends();
        Friend GetFriendById(int id);
        int AddFriend(Friend entity);
        int UpdateFriend(Friend entity);
        void DeleteFriend(Friend entity);
    }
}
