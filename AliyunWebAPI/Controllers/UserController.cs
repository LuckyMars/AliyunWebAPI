using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AliyunWebAPI.Models;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AliyunWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        public IUserRepository UserItems { get; set; }

        public UserController(IUserRepository userItems)
        {
            UserItems = userItems;
        }

        public IActionResult GetAll()
        {
            return new ObjectResult(MongoHelper.GetAllData());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {

            return new ObjectResult(UserItems.FindOneById(id));
        }

        [HttpPost]
        public void Create([FromBody]UserItem item)
        {
            UserItems.Create(item);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UserItem data)
        {
            var result = UserItems.Update(data);
            return new ObjectResult(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var result = UserItems.Delete(id);
            return new ObjectResult(result);
        }
    }
}
