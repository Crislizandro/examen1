using examen1.models;
using System;
using System.Threading.Tasks;

namespace examen1.controllers
{
    public class databaseBase
    {

        //CRUD
        public Task<int> Addcontacto(models.contacto contact)
        {
            if (contact.id == 0)
            {
                return _connection.InsertAsync(contact);
            }
            else
            {
                return _connection.UpdateAsync(contact);
            }
        }

        internal Task<int> addcontacto(contacto contacto)
        {
            throw new NotImplementedException();
        }
    }
}