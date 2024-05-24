using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rate = MauiApp1.Entities.Rate;

namespace MauiApp1.Services
{
    public interface IRateService
    {
        IEnumerable<Rate> GetRates(DateTime date);
        IEnumerable<Rate> GetMyRates(DateTime date);
    }
}
