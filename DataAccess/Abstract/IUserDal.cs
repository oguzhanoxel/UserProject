using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IUserDal
    {
        User Get(Func<User, bool> filter);
        List<User> GetAll(Func<User, bool> filter = null);
        void Add(User user);
        void Update(User user);
        void Delete(User user);

    }
}
