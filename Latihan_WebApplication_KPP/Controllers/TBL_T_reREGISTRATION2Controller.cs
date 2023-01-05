using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Latihan_WebApplication_KPP;
using Latihan_WebApplication_KPP.Models;

namespace Latihan_WebApplication_KPP.Controllers
{
    public class TBL_T_reREGISTRATION2Controller : ApiController
    {

        reRegistration2DataContext db = new reRegistration2DataContext();

        // GET: api/TBL_T_reREGISTRATION2
        //[EnableCors(origins: "https://localhost:44392", headers: "*", methods: "*")]
        public IHttpActionResult GetTBL_T_reREGISTRATION2()
        {
            // NRP, NAMA, TELEPON, EMAIL
            return Ok(new {message = "berhasil", data = db.TBL_T_reREGISTRATION2s.Select(x => new {NRP = x.NRP, Nama = x.NAMA, Telepon = x.NO_HP, Email = x.EMAIL})}) ;

        }

    }
}