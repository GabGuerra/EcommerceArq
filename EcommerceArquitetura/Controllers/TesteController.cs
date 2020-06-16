using EcommerceArquitetura.Infraestrutura.Business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceArquitetura.Controllers
{
    public class TesteController : Controller
    {
        public string Teste()
        {
            using (var bl = new TesteBL())
                return JsonConvert.SerializeObject(bl.Teste());
        }
    }
}