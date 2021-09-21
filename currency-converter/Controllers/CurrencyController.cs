using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using currency_converter.Models;
using System.Net;
using Microsoft.VisualBasic.CompilerServices;

namespace currency_converter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : Controller
    {

        // GET: api/Currency/5
        [Route("{baseCurrency}/{endCurrency}/{amount}/{date?}")]
        public double Get(string baseCurrency, string endCurrency, int amount, string? date =null)
        {
            RateModel rate = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://data.fixer.io/api/");
                var responseTask = client.GetAsync( (date==null ? "latest" : date) + "?access_key=983806a73bf11a660b6f6e24da0317d9&base=" + baseCurrency + "&symbols=" + endCurrency);
               
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Models.RateModel>();
                    readTask.Wait();

                    rate = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    return 0;

                }
            }

            return Convert.ToDouble(rate.Rates[0]) * amount;
        }
        

        // GET: api/Currency/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
