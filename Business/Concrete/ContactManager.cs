using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Add(Contact contact)
        {
            _contactDal.Add(contact);
        }

        public void Delete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public Contact Get(int contactId)
        {
            return _contactDal.Get(c => c.Id == contactId);
        }

        public List<Contact> GetAll()
        {
            return _contactDal.GetAll();
        }

        public List<Contact> GetAllByUser(int userId)
        {
            return _contactDal.GetAll(c => c.UserId == userId);
        }

        public void Update(Contact contact)
        {
            _contactDal.Update(contact);
        }
    }
}
