using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using TinyMce.Models;

namespace TinyMce.Controllers
{
    public class TinyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public MemoryStream Index(ExampleClass model)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri("http://webapi/pdf/?html=" + model.HtmlContent);
                var response = client.SendAsync(request).Result;
                return new MemoryStream(response.Content.ReadAsByteArrayAsync().Result);
            }
        }
    }
    public class ExampleClass
    {
        public string HtmlContent { get; set; }

        public ExampleClass()
        {

        }
    }
}
