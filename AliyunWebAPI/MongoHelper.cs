using AliyunWebAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliyunWebAPI
{
    public class MongoHelper
    {
        private static readonly IMongoCollection<UserItem> _mycol;

        static MongoHelper()
        {
            string connectString = "mongodb://127.0.0.1:27017";
            string dataBaseName = "test";
            string collectionName = "mycol";
            MongoClient mc = new MongoClient(connectString);
            _mycol = mc.GetDatabase(dataBaseName).GetCollection<UserItem>(collectionName);
        }


        public static void InsertData(UserItem DataS)
        {
            _mycol.InsertOne(DataS);
        }

        public static bool DeleteData(ObjectId objectId)
        {
            var filter = Builders<UserItem>.Filter.Eq("_id", objectId);
            var result = _mycol.DeleteOne(filter);
            return result.IsAcknowledged;
        }

        public static bool UpdateData(UserItem updataDs)
        {
            var filter = Builders<UserItem>.Filter.Eq("_id", updataDs._id);
            var result = _mycol.ReplaceOne(filter, updataDs);
            return result.IsAcknowledged;
        }

        public static UserItem SearchData(ObjectId objectId)
        {
            var filter = Builders<UserItem>.Filter.Eq("_id", objectId);
            var result = _mycol.Find(filter);
            return result.FirstOrDefault();
        }

        public static List<UserItem> GetAllData()
        {
            return _mycol.AsQueryable().ToList();
        }
    }
}
