using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirmaDigital.Models
{
    public class Signature
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public byte[] ImageData { get; set; }
        public string Description { get; set; }
    }

}
