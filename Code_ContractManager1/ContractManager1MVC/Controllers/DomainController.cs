using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContractManager1MVC.helper;
using ContractManager1MVC.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace ContractManager1MVC.Controllers
{
    public class DomainController : Controller
    {
        Contract _api = new Contract();
        public async Task<IActionResult> Index()
        {

            List<Domain> studentDatas = new List<Domain>();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync("api/Domains");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                studentDatas = JsonConvert.DeserializeObject<List<Domain>>(res);
            }


            return View(studentDatas);
        }
    }
}
