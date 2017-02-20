using System;
using System.Collections.Generic;
using ContactManagement.Models;
using ContactManagement.Logging;

namespace ContactManagement.Repository
{
    public class ContactRepository : IContactRepository
    {
        ILog logger = new Log();
        ContactEntities contactDb = new ContactEntities();
        public List<Contacts> GetAllContact()
        {
            List<Contacts> contacts = new List<Contacts>();
            try
            {


                var result = contactDb.GetAllContact();
                foreach (var data in result)
                {
                    contacts.Add(
                        new Contacts
                        {
                            AddressId = data.AddressId,
                            City = data.City,
                            Direction = data.Direction,
                            FirstName = data.FirstName,
                            LastName = data.LastName,
                            Mi = data.Mi,
                            State = data.State,
                            Street = data.Street_,
                            StreetName = data.StreetName,
                            StreetType = data.StreetType,
                            SubjectId = data.SubjectId,
                            Suffix = data.Suffix,
                            Zip = data.Zip

                        });

                }
            }
            catch (Exception ex)
            {
                logger.Log(ex);
            }
            return contacts;
        }

        public void SaveContact(Contacts contact)
        {
            try
            {
                if (contact != null)
                {
                    contactDb.SaveContact(
                            contact.FirstName,
                            contact.LastName,
                            contact.Mi,
                            contact.Suffix,
                            contact.Street,
                            contact.Direction,
                            contact.StreetName,
                            contact.StreetType,
                            contact.City,
                            contact.State,
                            contact.Zip
                        );
                }
            }
            catch (Exception ex)
            {
                logger.Log(ex);
            }
        }
    }
}