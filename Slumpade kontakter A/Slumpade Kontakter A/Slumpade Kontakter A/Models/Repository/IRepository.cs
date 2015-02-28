using System;
using System.Collections.Generic;
namespace Slumpade_Kontakter_A.Models.Repository
{
    public interface IRepository
    {
        void AddContact(Contact contact);

        Contact GetContact(Guid id);

        List<Contact> GetContact();

        void EditContact(Contact contact);

        void DeleteContact(Contact contact);

        void Save();
    }
}
