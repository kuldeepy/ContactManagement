using ContactManagement.Models;
using ContactManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ContactManagement.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContactController : ApiController
    {
        IContactRepository repository = new ContactRepository();

        public IHttpActionResult Get()
        {
            var result = repository.GetAllContact();
            return Ok(result);
        }

        public IHttpActionResult Post(Contacts contact)
        {
            if (ModelState.IsValid)
            {
                repository.SaveContact(contact);
                return Ok("Contact Save successfully.");
            }
            else
            {
                return BadRequest("Invalid contact deatils");
            }
        }
    }
}
