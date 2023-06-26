using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace examen1.models
{
    [Table ("contacto")]
    public class contacto
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength (100)]
        public string nombre { get; set; }
        [NotNull, Unique]
        public string   telefono { get; set; }
        [NotNull]
        public string  edad { get; set; }
        [NotNull]
        public string pais { get; set; }
        [NotNull]
        public string nota { get; set; }
        public byte[] foto { get; set; }
    }
}
