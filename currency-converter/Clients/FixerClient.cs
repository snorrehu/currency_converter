using currency_converter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace currency_converter.Clients
{
    public class FixerClient
    {
        static HttpClient client = new HttpClient();

        static async Task<RateModel> GetRateAsync(string baseCurrency, string endCurrency, string date)
        {
            RateModel rate = null;
            string path = date == null ?
                "http ://data.fixer.io/api/latest?" + "access_key=983806a73bf11a660b6f6e24da0317d9" + "&base=" + baseCurrency + "&symbols=" + endCurrency : 
                "http://data.fixer.io/api/" + date + "?access_key=983806a73bf11a660b6f6e24da0317d9" + "&base=" + baseCurrency + "&symbols=" + endCurrency;


            HttpResponseMessage response = 
                await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                rate = await response.Content.ReadAsAsync<RateModel>();
            }
            return rate;
        }
    }
}
