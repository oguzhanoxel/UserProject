using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public List<User> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpGet("getalljson")]
        public async Task<IActionResult> GetAllJson()
        {
            var users = _userService.GetAll();
            return Content(JsonConvert.SerializeObject(users), "application/json");
        }

        [HttpGet("getallsorted-asc")]
        public List<User> GetAllSortedASC()
        {
            return _userService.GetAllSortedASC();
        }

        [HttpGet("getallsorted-desc")]
        public List<User> GetAllSortedDESC()
        {
            return _userService.GetAllSortedDESC();
        }

        [HttpGet("get")]
        public User Get(int userId)
        {
            return _userService.Get(userId);
        }

        [HttpPost("add")]
        public string Add(User user)
        {
            _userService.Add(user);
            return "added.";
        }

        [HttpPost("addimage")]
        public void AddUserImage(IFormFile file, int userId)
        {
            _userService.AddUserImage(userId, file);
        }

        [HttpPost("updateimage")]
        public void UpdateUserImage(IFormFile file, int userId)
        {
            _userService.UpdateUserImage(userId, file);
        }

        [HttpPost("update")]
        public string Update(User user)
        {
            _userService.Update(user);
            return "updated.";
        }

        [HttpPost("delete")]
        public string Delete(User user)
        {
            _userService.Delete(user);
            return "deleted.";
        }
    }
}
