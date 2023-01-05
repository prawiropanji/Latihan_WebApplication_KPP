using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Latihan_WebApplication_KPP;
using Latihan_WebApplication_KPP.Models;
using Latihan_WebApplication_KPP.ViewModels;

namespace Latihan_WebApplication_KPP.Controllers
{
    public class TBL_T_BIODATAController : ApiController
    {
        private Models.DataBiodataDataContext db = new DataBiodataDataContext();
        //private DB_ICT_LEARNING_KPTEntities db = new DB_ICT_LEARNING_KPTEntities();

        private CLS_Biodata cLS_Biodata = new CLS_Biodata();

        // GET: api/TBL_T_BIODATA
        [HttpGet]
        public IHttpActionResult GetTBL_T_BIODATA()
        {
            return Ok(new { message = "berhasil", data = cLS_Biodata.getListDoneRequest() });
        }

        //[HttpGet]
        //[Route("api/RequestCoal/getListDoneRequest")]
        //public IHttpActionResult getListDoneRequest()
        //{



        //    try
        //    {
        //        ClsRequestCoal clsRequestCoal = new ClsRequestCoal();
        //        var data = clsRequestCoal.getListDoneRequest();

        //        return Ok(new { Status = true, Data = data, Total = data.Count() });
        //    }
        //    catch (Exception e)
        //    {
        //        return Ok(new { Status = false, Error = e.ToString() });
        //    }
        //}

        // GET: api/TBL_T_BIODATA/5
        //[ResponseType(typeof(TBL_T_BIODATA))]
        //public IHttpActionResult GetTBL_T_BIODATA(string id)
        //{
        //    TBL_T_BIODATA tBL_T_BIODATA = db.TBL_T_BIODATA.Find(id);
        //    if (tBL_T_BIODATA == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(tBL_T_BIODATA);
        //}

        //    // PUT: api/TBL_T_BIODATA/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutTBL_T_BIODATA(string id, Models.TBL_T_BIODATA tBL_T_BIODATA)
        {
           int affectedRow =  cLS_Biodata.ModifyData(tBL_T_BIODATA);

            if (affectedRow > 0)
            {
            return Ok( new { message = "update data success" } );

            }    
       
           

           
          return Ok(new { message = "fail to update" });
         
      

        }

        // POST: api/TBL_T_BIODATA
        [ResponseType(typeof(TBL_T_BIODATA))]
        [HttpPost]
        public IHttpActionResult PostTBL_T_BIODATA(Models.TBL_T_BIODATA tBL_T_BIODATA)
        {
           

            try
            {
            cLS_Biodata.ModifyData(tBL_T_BIODATA);

            }catch(Exception ex)
            {
                return Ok(new { message = ex.Message });
            }


            return Ok(new { message = "insert data success" });
        }

        // DELETE: api/TBL_T_BIODATA/5
        [ResponseType(typeof(TBL_T_BIODATA))]
        [HttpPost]
        [Route("api/TBL_T_BIODATA/delete")]
        public IHttpActionResult Delete(string NRP)
        {
 
            int rowAffected = cLS_Biodata.DeleteData(NRP);

            if(rowAffected > 0)
            {

            return Ok(new { message = "delete berhasil"});
            }

            return Ok(new { message = "delete gagal" });

        

        }


    
    }
}
