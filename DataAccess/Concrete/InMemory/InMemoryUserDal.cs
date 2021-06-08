using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryUserDal : IUserDal
    {
        List<User> _users;
        IContactDal _contactDal;

        public InMemoryUserDal(IContactDal contactDal)
        {
            _users = new List<User>
            {
                new User{Id = 1, Name = "Oğuzhan", Surname = "Öksel", Email = "oguzhanoksel@hotmail.com", BirthDate = new DateTime(1996, 11, 13), Location = "İstanbul, Şişli/Mecidiyeköy", Phone = "5346238913", ImagePath = "images/default.png"},
                new User{Id = 2, Name = "Praesent", Surname = "Suscipit", Email = "Suscipit@example.com", BirthDate = new DateTime(1998, 10, 11), Location = "Integer et nisl a nunc vestibulum pretium.", Phone = "5050000000", ImagePath = "images/default.png"},
                new User{Id = 3, Name = "Dui", Surname = "Sit", Email = "Sit@example.com", BirthDate = new DateTime(1990, 8, 20), Location = "Quisque luctus dolor nibh, et condimentum neque accumsan eu.", Phone = "5090000000", ImagePath = "images/default.png"},
                new User{Id = 4, Name = "Amet", Surname = "Neque", Email = "Neque@example.com", BirthDate = new DateTime(1992, 11, 3), Location = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Phone = "5200000000", ImagePath = "images/default.png"},
                new User{Id = 5, Name = "Commodo", Surname = "Tempor", Email = "Tempor@example.com", BirthDate = new DateTime(1986, 7, 13), Location = "Aliquam erat volutpat. Ut lorem felis, gravida at luctus ut, fermentum a purus.", Phone = "58000000000", ImagePath = "images/default.png"},
                new User{Id = 6, Name = "Donec", Surname = "Eget", Email = "Eget@example.com", BirthDate = new DateTime(1993, 11, 3), Location = "Etiam commodo, urna sed tristique ullamcorper, augue lorem faucibus nunc, et lacinia est nunc non augue.", Phone = "5890000000", ImagePath = "images/default.png"},
                new User{Id = 7, Name = "Commodo", Surname = "Blandit", Email = "Blandit@example.com", BirthDate = new DateTime(1986, 7, 13), Location = "Pellentesque sodales dapibus libero, ut luctus nunc laoreet ac.", Phone = "58000000000", ImagePath = "images/default.png"},
                new User{Id = 8, Name = "Commodo", Surname = "Aliquet", Email = "Aliquet@example.com", BirthDate = new DateTime(1991, 8, 13), Location = "vitae rhoncus sem facilisis ac. In feugiat quam metus, non tincidunt risus rutrum eu.", Phone = "58000000000", ImagePath = "images/default.png"},
                new User{Id = 9, Name = "Commodo", Surname = "Donec", Email = "Donec@example.com", BirthDate = new DateTime(1999, 2, 11), Location = "Aenean blandit nulla et quam blandit blandit. Aliquam interdum nunc id nibh suscipit, at ultricies massa efficitur.", Phone = "58000000000", ImagePath = "images/default.png"},

            };
            _contactDal = contactDal;
        }

        public void Add(User user)
        {
            user.Id = _users.Last().Id + 1;
            _users.Add(user);
        }

        public void Delete(User user)
        {
            User userToDelete = _users.SingleOrDefault(u => u.Id == user.Id);
            _users.Remove(userToDelete);
        }

        public User Get(Func<User, bool> filter)
        {
            return _users.SingleOrDefault(filter);
        }

        public List<User> GetAll(Func<User, bool> filter = null)
        {
            return filter == null ? _users.ToList() : _users.Where(filter).ToList();
        }
        public void Update(User user)
        {
            User userToUpdate = _users.SingleOrDefault(u => u.Id == user.Id);

            userToUpdate.Id = user.Id;
            userToUpdate.Name = user.Name;
            userToUpdate.Surname = user.Surname;
            userToUpdate.Email = user.Email;
            userToUpdate.BirthDate = user.BirthDate;
            userToUpdate.Location = user.Location;
            userToUpdate.Phone = user.Phone;
        }
    }
}
