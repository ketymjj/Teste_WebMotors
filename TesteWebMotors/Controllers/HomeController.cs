using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TesteWebMotors.Models;
using TesteWebMotors.Repository;

namespace TesteWebMotors.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/values/");
                response.EnsureSuccessStatusCode();
                List<VeiculosViewModel> products = response.Content.ReadAsAsync<List<VeiculosViewModel>>().Result;
                ViewBag.Title = "All Veiculos";
                return View(products);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VeiculosViewModel veiculo)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            var response = serviceObj.PostResponse("api/values/Post", veiculo);

            //HTTP POST
            var postTask = response;
            postTask.ToString();

            var result = postTask;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(veiculo);
        }

        public ActionResult Edit(int id)
        {

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/values/GetById?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            VeiculosViewModel veiculos = response.Content.ReadAsAsync<VeiculosViewModel>().Result;
            ViewBag.Title = "All Veiculos";
            return View(veiculos);
        }

        [HttpPost]
        public ActionResult EditNew(VeiculosViewModel veiculos)
        {

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/values/Put", veiculos);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/values/Delete?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");

        }
    }
}
