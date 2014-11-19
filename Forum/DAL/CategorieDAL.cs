using Forum.DAL.Data;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using Forum.myDataSetTableAdapters;
using Forum.DAL.Data.Mappeur;

namespace Forum.DAL
{   
    public class CategorieDAL
    {
        public bool CreateCategorie(CategorieD cat)
        {
            using (ps_FOR_GetCategorieTableAdapter CategorieDal = new ps_FOR_GetCategorieTableAdapter())
            {
                CategorieDal.ps_FOR_CreateCategorie(cat.Forum_id, cat.Nom);
            }
                return true;
            }

        public bool EditCategorie(CategorieD cat)
        {
            using (ps_FOR_GetCategorieTableAdapter CategorieDal = new ps_FOR_GetCategorieTableAdapter())
        {
                CategorieDal.ps_FOR_UpdateCategorie(cat.Sujet_id, cat.Nom);
        }
            return true;
        }

        public bool DeleteCategorie(int Sujet_id)
        {
            using (ps_FOR_GetCategorieTableAdapter CategorieDal = new ps_FOR_GetCategorieTableAdapter())
            {
                CategorieDal.ps_FOR_DeleteCategorie(Sujet_id);
            }
            return true;
        }

        public List<CategorieD> GetListCategorie()
        {
            myDataSet.ps_FOR_GetCategorieDataTable datatable;
            using (ps_FOR_GetCategorieTableAdapter CategorieDal = new ps_FOR_GetCategorieTableAdapter())
            {
            datatable = CategorieDal.ps_FOR_GetListCategorie();
            }
            return CategorieMappeur.ToCategorieD(datatable).ToList();
        }

        public List<CategorieD> GetListCategorieByForum(int forum_id)
        {
            myDataSet.ps_FOR_GetCategorieDataTable datatable;

            using (ps_FOR_GetCategorieTableAdapter CategorieDal = new ps_FOR_GetCategorieTableAdapter())
            {
            datatable = CategorieDal.ps_FOR_GetListCategorieByForum(forum_id);
            }
            return CategorieMappeur.ToCategorieD(datatable).ToList();
        }

        internal CategorieD GetCategorie(int id)
            {
            myDataSet.ps_FOR_GetCategorieDataTable datatable;
            using (ps_FOR_GetCategorieTableAdapter CategorieDal = new ps_FOR_GetCategorieTableAdapter())
            {
                datatable = CategorieDal.ps_FOR_GetCategorie(id);
        }
            return CategorieMappeur.ToCategorieD(datatable).ElementAt(0);
        }
    }
}