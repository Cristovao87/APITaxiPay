using APITaxiPay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TaxiPay.Helper;
using TaxiPay.Models;

namespace TaxiPay.Controllers
{
    public class HomeController : Controller
    {
       TaxiAPI _api = new TaxiAPI();

        public async Task<IActionResult> Index()
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/pessoas");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(results);
            }
            return View(pessoas);
        }


        public async Task<IActionResult> Details(int Id)
        {

            var pessoa = new Pessoa();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/pessoas/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                pessoa = JsonConvert.DeserializeObject<Pessoa>(results);
            }


            return View(pessoa);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Pessoa pessoa)
        {
            HttpClient client = _api.Initial();

            // HTTP POST
            var postTask = client.PostAsJsonAsync<Pessoa>("api/pessoas", pessoa);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var student = new Pessoa();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/pessoas/{Id}");

            return RedirectToAction("Index");
        }








        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
