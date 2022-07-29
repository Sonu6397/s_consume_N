using Newtonsoft.Json;
using s_consume_N.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace s_consume_N.Controllers
{
    public class StudentController : Controller
    {
        Uri apiuri = new Uri("http://localhost:60721/");
        HttpClient client;

        public StudentController()
        {
            client = new HttpClient();
            client.BaseAddress = apiuri;
        }
        // GET: Student
        public ActionResult Index()
        {
            List<Empmodel> obj = new List<Empmodel>();
            HttpResponseMessage obj1 = client.GetAsync(client.BaseAddress + "Account/Index").Result;
            if (obj1.IsSuccessStatusCode)
            {
                string res = obj1.Content.ReadAsStringAsync().Result;
                obj = JsonConvert.DeserializeObject<List<Empmodel>>(res);
            }
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Empmodel d)
        {
            string res = JsonConvert.SerializeObject(d);
            StringContent content = new StringContent(res, Encoding.UTF8, "application/json");
            HttpResponseMessage listobj = client.PostAsync(client.BaseAddress + "Account/Create", content).Result;
            if (listobj.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int? id)
        {
            Empmodel obj = new Empmodel();
            HttpResponseMessage listobj = client.GetAsync(client.BaseAddress + "Account/GetEdit" + "?id=" + id).Result;
            if (listobj.IsSuccessStatusCode)
            {
                string res = listobj.Content.ReadAsStringAsync().Result;
                obj = JsonConvert.DeserializeObject<Empmodel>(res);
            }
            return View(obj);
        }
        [HttpPost]

        public ActionResult Edit(Empmodel a)
        {
            string res = JsonConvert.SerializeObject(a);
            StringContent content = new StringContent(res, Encoding.UTF8, "application/json");
            HttpResponseMessage listobj = client.PutAsync(client.BaseAddress + "Account/PostEdit", content).Result;
            if (listobj.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View(listobj);
        }

        public ActionResult Delete(int id)
        {
            Empmodel obj = new Empmodel();
            HttpResponseMessage listobj = client.GetAsync((client.BaseAddress + "Account/Delete" + "?id=" + id).ToString()).Result;
            if (listobj.IsSuccessStatusCode)
            {
                var res = listobj.Content.ReadAsStringAsync().Result;
                obj = JsonConvert.DeserializeObject<Empmodel>(res);
            }
            return RedirectToAction("Index");
        }
    }
}