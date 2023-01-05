using Latihan_WebApplication_KPP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;

namespace Latihan_WebApplication_KPP.ViewModels
{
    public class CLS_Biodata
    {
        DataBiodataDataContext db = new DataBiodataDataContext();

        public IQueryable<cufn_getBiodataByPanjiResult> getListDoneRequest()
        {
            var data = db.cufn_getBiodataByPanji().OrderBy(x => x.NRP);
            return data;
        }


        public int ModifyData(Models.TBL_T_BIODATA tBL_T_BIODATA)
        {
            try
            {
                var data = db.TBL_T_BIODATAs.Where(x => x.NRP == tBL_T_BIODATA.NRP).FirstOrDefault();


                if (data != null)
                {
                    string nrp = tBL_T_BIODATA.NRP;
                    string nama = tBL_T_BIODATA.NAMA;
                    string telepon = tBL_T_BIODATA.TELEPON;
                    string email = tBL_T_BIODATA.EMAIL;
                    return db.cusp_updateData(nrp, nama, telepon, email);
                }
                else
                {
                    db.TBL_T_BIODATAs.InsertOnSubmit(tBL_T_BIODATA);
                    db.SubmitChanges();
                    return 1;
                }


            }catch
            {
                return 0;
            }


        }

        public int DeleteData(string NRP)
        {
            var data = db.cusp_deleteDataByNRP(NRP);

            return data;

            //var data = db.TBL_T_BIODATAs.FirstOrDefault(x => x.NRP == NRP);
            //db.TBL_T_BIODATAs.DeleteOnSubmit(data);
            //db.SubmitChanges();

        }

    }
}