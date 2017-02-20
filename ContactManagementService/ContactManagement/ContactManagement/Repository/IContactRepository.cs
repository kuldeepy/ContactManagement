using ContactManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Repository
{
    public interface IContactRepository
    {
        List<Contacts> GetAllContact();

        void SaveContact(Contacts contact);

    }
}
