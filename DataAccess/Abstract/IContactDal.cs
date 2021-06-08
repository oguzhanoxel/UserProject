using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IContactDal
    {
        Contact Get(Func<Contact, bool> filter);
        List<Contact> GetAll(Func<Contact, bool> filter = null);
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(Contact contact);
    }
}
