using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CuantoVa.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Cod { get; set; }
        [MaxLength(255)]
        public string Codbar { get; set; }
        [MaxLength(255)]
        public string Cantidad { get; set; }
        [MaxLength(255)]
        public string Descitem{ get; set; }
        [MaxLength(255)]
        public string Precio { get; set; }
        
   
    }
}
