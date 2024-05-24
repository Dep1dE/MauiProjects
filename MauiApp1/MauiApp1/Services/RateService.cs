using Rate = MauiApp1.Entities.Rate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace MauiApp1.Services
{
    public class RateService: IRateService
    {
        HttpClient client;
        public RateService(HttpClient _client) {
            client = _client;
        }
        public IEnumerable<Rate> GetRates(DateTime date)
        {
            var response=client.GetAsync($"?ondate={date:yyyy-MM-dd}&periodicity=0").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var rates = JsonConvert.DeserializeObject<List<Rate>>(content);
            return rates;
        }

        public IEnumerable<Rate> GetMyRates(DateTime date)
        {
            List<Rate> rates = (List<Rate>)GetRates(date);
            List<Rate> myrates = new List<Rate>();
            try
            {
                myrates.Add(rates[21]);
                myrates.Add(rates[9]);
                myrates.Add(rates[7]);
                myrates.Add(rates[30]);
                myrates.Add(rates[16]);
                myrates.Add(rates[27]);
            }
            catch (Exception ex) { }
            return myrates;
        }
    }
}
    