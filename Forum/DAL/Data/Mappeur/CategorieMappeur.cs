using System;
using System.Collections.Generic;
using System.Linq;
using CategorieTable = Forum.myDataSet.ps_FOR_GetCategorieDataTable;
using CategorieRow = Forum.myDataSet.ps_FOR_GetCategorieRow;
using System.Web;

namespace Forum.DAL.Data.Mappeur
{
    public static class CategorieMappeur
    {
        public static IEnumerable<CategorieD> ToCategorieD(this CategorieTable table )
        {
            List<CategorieD> list = new List<CategorieD>();
            foreach (CategorieRow item in table.Rows)
	        {
                list.Add(ToCategorieD(item));
	        }
            return list;
        }

        public static CategorieD ToCategorieD(this CategorieRow row)
        {
            CategorieD d = new CategorieD();
            d.Nom = row.Nom;
            d.Sujet_id = row.Sujet_id;
            d.Forum_id = row.Forum_id;
            return d;
        }
    }
}