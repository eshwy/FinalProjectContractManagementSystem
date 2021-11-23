using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ContractManager1MVC.helper;
using ContractManager1MVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ContractManager1MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly string wwwrootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;
        public HomeController(ILogger<HomeController> logger,IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
        }

        Contract _api = new Contract();

        //HOMEPAGE
        public IActionResult Homepage()
        {
            return View();
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //idex method
        public async Task<IActionResult> Index()
        {
            List<ContractDetail> indexdetails = new List<ContractDetail>();
            List<string> docs = Directory.GetFiles(wwwrootDirectory).Select(Path.GetFileName).ToList();            

            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync("api/ContractDetails");

            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                indexdetails = JsonConvert.DeserializeObject<List<ContractDetail>>(res);                
            }
            return View(indexdetails);
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //create
        public async Task<IActionResult> create()
        {

            List<Domain> alldomains = new List<Domain>();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync("api/Domains");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                alldomains = JsonConvert.DeserializeObject<List<Domain>>(res);
                ViewBag.JobType = new SelectList(alldomains, "Alldomains", "Alldomains");
            }
            return View();
        }


        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        //post the data to the api
        [HttpPost]
        public async Task<IActionResult> create(ContractDetail student)
        {
            

            student.CreatedDate = DateTime.Now;
            student.ModifiedDate = DateTime.Now;
            student.RecordStatus = true;
            student.DateOfBirth = DateTime.Now;

            HttpClient cli = _api.Initial();
            string authornew = JsonConvert.SerializeObject(student);
            StringContent content = new StringContent(authornew, Encoding.UTF8, "application/json");
            HttpResponseMessage response = cli.PostAsync(cli.BaseAddress + "api/ContractDetails", content).Result;
            if (response.IsSuccessStatusCode)
            {
                
                return RedirectToAction("Index");
            }
            return View();
        }


        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //edit data 
        public async Task<IActionResult> Edit(string id)
        {
            List<Domain> domaindata = new List<Domain>();
            HttpClient cli = _api.Initial();
            ContractDetail stud = new ContractDetail();
            HttpResponseMessage response = await cli.GetAsync($"api/ContractDetails/{id}");

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                stud = JsonConvert.DeserializeObject<ContractDetail>(data);
                ViewBag.JobType = new SelectList(domaindata, "Alldomains", "Alldomains");

            }
            return View(stud);

        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //post edited data to api
        [HttpPost]
        public async Task<IActionResult> Edit(string id, [Bind("ContractId", "WorkerName", "WorkerNumber", "Gender",
            "Email","CurrentAddress","Domain","Project","WorkLocation","StartDatee","EndDate","DescriptionDetails",
            "Amount","CreatedDate","ModifiedDate","RecordStatus","file_path")] ContractDetail model)
        {
            model.ModifiedDate = DateTime.Now ;
            model.CreatedDate = DateTime.Now;
            model.RecordStatus = true ;
            model.DateOfBirth = DateTime.Now; ;
            if (id != model.ContractId)
            {
                return NotFound();
            }
            HttpClient cli = _api.Initial();
            string detailput = JsonConvert.SerializeObject(model);            
            StringContent content = new StringContent(detailput, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await cli.PutAsync($"api/ContractDetails/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }           

            return View();
        }


        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //returns all the data from the db with same email-id
        public async Task<IActionResult> Details(string email)
        {
            List<ContractDetail> emaildata = new List<ContractDetail>();           


            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync($"api/ContractDetailsParticular/{email}");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                emaildata = JsonConvert.DeserializeObject<List<ContractDetail>>(res);               

            }
            return View(emaildata);
        }


        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        //return the indiviual values of the data using contract id
        public async Task<IActionResult> Details1(string id)
        {
            var indivudualdetails = new ContractDetail();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync($"api/ContractDetails/{id}");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                indivudualdetails = JsonConvert.DeserializeObject<ContractDetail>(res);
            }
            return View(indivudualdetails);
        }



        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        

       //priacy page
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
