using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Entities
{
    [Table("Patients")]
    public class Patient
    {
        [PrimaryKey, AutoIncrement, Indexed]
        [Column("Id")]
        public int PatientId { get; set; }
        public string? Fio { get; set; }
        public string? Diagnosis { get; set; }
        public int TreatmentDays { get; set; }
        [Indexed]
        public int WardId { get; set; }
    }
}
