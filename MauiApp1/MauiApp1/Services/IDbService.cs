using MauiApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MauiApp1.Services
{
    public interface IDbService
    {
        IEnumerable<Ward> GetAllWards();
        IEnumerable<Patient> GetWardPatients(int wardId);
        void Init();
    }
}
