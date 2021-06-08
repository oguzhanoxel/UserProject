using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        User Get(int userId);
        List<User> GetAll();
        List<User> GetAllSortedASC();
        List<User> GetAllSortedDESC();
        void AddUserImage(int userId, IFormFile file);
        void UpdateUserImage(int userId, IFormFile file);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
