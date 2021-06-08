using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {

        IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("getall")]
        public List<Contact> GetAll()
        {
            return _contactService.GetAll();
        }

        [HttpGet("get")]
        public Contact Get(int contactId)
        {
            return _contactService.Get(contactId);
        }

        [HttpPost("add")]
        public string Add(Contact contact)
        {
            _contactService.Add(contact);
            return "added.";
        }

        [HttpPost("delete")]
        public string Delete(Contact contact)
        {
            _contactService.Delete(contact);
            return "deleted.";
        }

        [HttpPost("update")]
        public string Update(Contact contact)
        {
            _contactService.Update(contact);
            return "updated.";
        }

    }
}
