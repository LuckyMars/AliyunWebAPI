using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliyunWebAPI.Models
{
    public class UserRepository: IUserRepository
    {
        public void Create(UserItem jsString)
        {
            MongoHelper.InsertData(jsString);
        }

        public bool Delete(string id)
        {
            return MongoHelper.DeleteData(ObjectId.Parse(id));
        }

        public UserItem FindOneById(string id)
        {
            return MongoHelper.SearchData(ObjectId.Parse(id));
        }

        public List<UserItem> GetAll()
        {
            return MongoHelper.GetAllData();
        }

        public bool Update(UserItem jsString)
        {
            return MongoHelper.UpdateData(jsString);
        }
    }
}
