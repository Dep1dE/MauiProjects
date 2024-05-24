using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Entities
{
    [Table("Wards")]
    public class Ward
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int Id { get; set; }
        public int Number { get; set; }
        public string? FioMainDoctor { get; set; }
        public int CountBeds { get; set; }
    }
}
