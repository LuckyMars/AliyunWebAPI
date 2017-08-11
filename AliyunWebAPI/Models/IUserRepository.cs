using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace AliyunWebAPI.Models
{
    public interface IUserRepository
    {
        void Create(UserItem jsString);
        bool Update(UserItem jsString);
        bool Delete(string id);
        List<UserItem> GetAll();
        UserItem FindOneById(string id);
    }
}
