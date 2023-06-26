using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Examen1.controllers
{
    public class database
    {
        readonly SQLiteAsyncConnection _connection;
        public database() { }

        public database(string dbpath)
        {
            _connection = new SQLiteAsyncConnection(dbpath);
            // Creacion de Base de Datos
            _connection.CreateTableAsync<examen1.models.contacto>().Wait();

        }

        //CRUD
        public Task<int> addcontacto(examen1.models.contacto contact)
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

        public Task<List<examen1.models.contacto>> obtenerlistacontacto()
        {
            return _connection.Table<examen1.models.contacto>().ToListAsync();
        }

        public Task<examen1.models.contacto> obtenercontacto(int pid)
        {
            return _connection.Table<examen1.models.contacto>().Where(i => i.id == pid).FirstOrDefaultAsync();
        }

        public Task<int> deletecontacto(examen1.models.contacto contact)
        {
            return _connection.DeleteAsync(contact);
        }
    }
}