using MauiApp1.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class SQLiteService: IDbService
    {
        const string DatabaseFileName = "Database.db3";

        string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);

        const SQLite.SQLiteOpenFlags Flags = 
                                SQLite.SQLiteOpenFlags.ReadWrite |
                                SQLite.SQLiteOpenFlags.Create |   
                                SQLite.SQLiteOpenFlags.SharedCache;

        SQLiteConnection Database;

        public SQLiteService() 
        {
            Database = new SQLiteConnection(DatabasePath, Flags);
        }

        public IEnumerable<Ward> GetAllWards()
        {
            return Database.Table<Ward>().ToList();
        }

        public IEnumerable<Patient> GetWardPatients(int wardId)
        {
            return Database.Table<Patient>().Where(patient => patient.WardId == wardId).ToList();
        }

        public void AddWard(Ward ward)
        {
            if(Database.Find<Ward>(ward.Id) == null) { Database.Insert(ward);}
        }

        public void AddPatient(Patient patient)
        {
            if (Database.Find<Patient>(patient.PatientId) == null) { Database.Insert(patient); }
        }
            



        public void Init()
        {
            Database.DeleteAll<Patient>();
            Database.DeleteAll<Ward>();
            Database.CreateTable<Patient>();
            Database.CreateTable<Ward>();
            

            List<Ward> wards =
            [
                new Ward{ Id=0, Number=1, FioMainDoctor="Bob", CountBeds=3 },
                new Ward{ Id=1, Number=2, FioMainDoctor="Frank", CountBeds=4 },
                new Ward{ Id=2, Number=3, FioMainDoctor="Tom", CountBeds=3 },
                new Ward{ Id=3, Number=4, FioMainDoctor="Alice", CountBeds=5 },
            ];

            List<Patient> patients =
            [
                new Patient{ PatientId=0, Diagnosis="ORI", Fio="Caleb", TreatmentDays=3, WardId=0 },
                new Patient{ PatientId=1, Diagnosis="DCP", Fio="Bob", TreatmentDays=5, WardId=0 },
                new Patient{ PatientId=2, Diagnosis="Alkoholism", Fio="Patric", TreatmentDays=8, WardId=0 },
                new Patient{ PatientId=3, Diagnosis="Ludoman", Fio="Biba", TreatmentDays=7, WardId=0 },
                new Patient{ PatientId=4, Diagnosis="Gripp", Fio="Alex", TreatmentDays=1, WardId=0 },
                new Patient{ PatientId=5, Diagnosis="CORONA", Fio="Frank", TreatmentDays=2, WardId=1 },
                new Patient{ PatientId=6, Diagnosis="COVID", Fio="Alaska", TreatmentDays=3, WardId=1 },
                new Patient{ PatientId=7, Diagnosis="ORI", Fio="Yagor", TreatmentDays=5, WardId=1 },
                new Patient{ PatientId=8, Diagnosis="ORI", Fio="Vlad", TreatmentDays=6, WardId=1 },
                new Patient{ PatientId=9, Diagnosis="Ludoman", Fio="Denis", TreatmentDays=1, WardId=1 },
                new Patient{ PatientId=10, Diagnosis="Alkoholism", Fio="Pety", TreatmentDays=2, WardId=2 },
                new Patient{ PatientId=11, Diagnosis="Gripp", Fio="Vanya", TreatmentDays=2, WardId=2 },
                new Patient{ PatientId=12, Diagnosis="ORI", Fio="Danic", TreatmentDays=7, WardId=2 },
                new Patient{ PatientId=13, Diagnosis="COVID", Fio="Faha", TreatmentDays=6, WardId=2 },
                new Patient{ PatientId=14, Diagnosis="DOTA2", Fio="Kosik", TreatmentDays=4, WardId=2 },
                new Patient{ PatientId=15, Diagnosis="DCP", Fio="Tom", TreatmentDays=3, WardId=3 },
                new Patient{ PatientId=16, Diagnosis="ORI", Fio="Jerry", TreatmentDays=2, WardId=3 },
                new Patient{ PatientId=17, Diagnosis="ORI", Fio="Max", TreatmentDays=1, WardId=3 },
                new Patient{ PatientId=18, Diagnosis="CORONA", Fio="Yan", TreatmentDays=4, WardId=3 },
                new Patient{ PatientId=19, Diagnosis="ORI", Fio="Fiksik", TreatmentDays=7, WardId=3 },
            ];

            wards.ForEach(ward => AddWard(ward));
            patients.ForEach(patient => AddPatient(patient));
        }
    }
}
