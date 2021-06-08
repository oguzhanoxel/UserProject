using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryContactDal : IContactDal
    {
        List<Contact> _contact;
        public InMemoryContactDal()
        {
            _contact = new List<Contact>
            {
                new Contact{Id=1, UserId=1, Title = "Github", Description = "https://github.com/oguzhanoxel"},
                new Contact{Id=2, UserId=1, Title = "LinkedIn", Description = "https://www.linkedin.com/in/oğuzhan-öksel-a61993197/"},
                new Contact{Id=3, UserId=2, Title = "E-mail", Description = "Proindigni@hotmail.com"},
                new Contact{Id=4, UserId=2, Title = "actem", Description = "www.actempusduibibenduma.com"},
                new Contact{Id=5, UserId=2, Title = "Nullam", Description = "www.Nullamloremtellus.com"},
                new Contact{Id=6, UserId=3, Title = "Aliqu", Description = "www.Aliquamnonsapienpurus.com"},
                new Contact{Id=7, UserId=4, Title = "Mauris", Description = "www.Maurisimperdietmalesuada.com"},
                new Contact{Id=8, UserId=4, Title = "Morbive", Description = "www.Morbivelnisisitametrisus.com"},
                new Contact{Id=9, UserId=5, Title = "Nullaveh", Description = "www.Nullavehiculaidfelisegetconsequat.com"},
                new Contact{Id=10, UserId=6, Title = "Crascon", Description = "www.Crasconguemiacnullafringilla.com"},
                new Contact{Id=11, UserId=6, Title = "turpissol", Description = "www.turpissollicitudineleifend.com"},
                new Contact{Id=12, UserId=7, Title = "Other Phone", Description = "50005000000"},
                new Contact{Id=13, UserId=7, Title = "suscipit", Description = "www.suscipitegestas mauris.com"},
                new Contact{Id=14, UserId=7, Title = "Prointin", Description = "www.Prointinciduntligula.com"},
                new Contact{Id=15, UserId=8, Title = "nequee", Description = "www.nequeeucommodo.com"},
                new Contact{Id=16, UserId=8, Title = "tristiquet", Description = "www.tristiquetellusaccumsanvitae.com"},
                new Contact{Id=17, UserId=9, Title = "ultricies", Description = "www.ultriciesgravida.com"},
                new Contact{Id=18, UserId=9, Title = "Whatsapp", Description = "5096000000"},
            };
        }

        public void Add(Contact contact)
        {
            contact.Id = _contact.Last().Id + 1;
            _contact.Add(contact);
        }

        public void Delete(Contact contact)
        {
            Contact contactToDelete = _contact.SingleOrDefault(c => c.Id == contact.Id);
            _contact.Remove(contactToDelete);
        }

        public Contact Get(Func<Contact, bool> filter)
        {
            return _contact.SingleOrDefault(filter);
        }

        public List<Contact> GetAll(Func<Contact, bool> filter = null)
        {
            return filter == null ? _contact.ToList() : _contact.Where(filter).ToList();
        }

        public void Update(Contact contact)
        {
            Contact contactToUpdate = _contact.SingleOrDefault(c => c.Id == contact.Id);
            contactToUpdate.Id = contact.Id;
            contactToUpdate.UserId = contact.UserId;
            contactToUpdate.Title = contact.Title;
            contactToUpdate.Description = contact.Description;
        }
    }
}
