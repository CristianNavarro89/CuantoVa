using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CuantoVa.Models
{
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Nombre { get; set; }
        [MaxLength(255)]
        public string Usuario { get; set; }
        [MaxLength(255)]
        public string Contrasenia { get; set; }
    }
}
