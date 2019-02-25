using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Notas.Modelos
{
    [Table("Nota")]
    public class Nota
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
