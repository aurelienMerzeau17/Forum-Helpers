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
        SqlConnection myConnection;

        string connexionstring = "data source=avip9np4yy.database.windows.net,1433;initial catalog=YoupDEV;persist security info=True;user id=youpDEV;password=youpD3VASP*;MultipleActiveResultSets=True;App=EntityFramework";
        ps_FOR_CategorieTableAdapter CategorieDal;

        public bool CreateCategorie(SqlInt32 sujet_id, SqlInt32 forum_id, SqlString nom)
        {
            try
            {
                myConnection = new SqlConnection("data source=avip9np4yy.database.windows.net,1433;initial catalog=YoupDEV;persist security info=True;user id=youpDEV;password=youpD3VASP*;MultipleActiveResultSets=True;App=EntityFramework");
                SqlCommand cmd = new SqlCommand();
                Int32 rowsAffected;

                cmd.CommandText = "ps_FOR_GetListCategorie";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = myConnection;

                myConnection.Open();

                rowsAffected = cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public CategorieDAL()
        {
            myConnection = new SqlConnection(connexionstring);
            CategorieDal = new ps_FOR_CategorieTableAdapter();
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public bool CreateCategorie(CategorieD cat)
        {
            int nbrow = CategorieDal.ps_FOR_UpdateCategorie(cat.Sujet_id, cat.Nom);
            //using (SqlCommand command = new SqlCommand())
            //{
            //    command.Connection = myConnection;
            //    command.CommandText = "INSERT INTO FOR_Sujet (Sujet_id, Forum_id, Nom) "
            //        + "Values (" + cat.Sujet_id + ", " + cat.Forum_id + ", '" + cat.Nom + "')";
            //    command.ExecuteNonQuery();
            //}
            if (nbrow > 0)
            {
                return true;
            }
            return false;
        }
        public bool EditCategorie(CategorieD cat)
        {
            try
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = myConnection;
                command.CommandText = "UPDATE FOR_Sujet SET Nom = '" + cat.Nom + "' WHERE Topic_id = " + cat.Sujet_id;
                command.ExecuteNonQuery();
            }
                return true;
            }
            catch
            {
                return false;
        }
        }

        public bool DeleteCategorie(int id)
        {
            try
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = myConnection;
                command.CommandText = "DELETE FROM FOR_Sujet WHERE Sujet_id = " + id;
                command.ExecuteNonQuery();
            }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<CategorieD> GetListCategorie()
        {
            List<CategorieD> ListC = new List<CategorieD>();
            using (SqlCommand command = new SqlCommand("SELECT * FROM FOR_Sujet", myConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListC.Add(new CategorieD
                        {
                            Forum_id = Convert.ToInt32(reader["Forum_id"]),
                            Nom = reader["Nom"].ToString(),
                            Sujet_id = Convert.ToInt32(reader["Sujet_id"])
                        });
                    }
                }
            }
            return ListC;
        }

        public List<CategorieD> GetListCategorieForum(int forum_id)
        {
            myDataSet.ps_FOR_CategorieDataTable datatable;
            if (forum_id == null)
            {
                datatable = CategorieDal.GetListCategory();
            }
            else
            {
                datatable = CategorieDal.GetListCategoryByForum(forum_id);
            }

            return CategorieMappeur.ToCategorieD(datatable).ToList();
        }

        public void Dispose()
        {
            try
            {
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        internal CategorieD GetCategorie(int id)
        {
            var lol = CategorieDal.ps_FOR_GetCategorie(id);
            return CategorieMappeur.ToCategorieD(lol).ElementAt(0);
        }
    }
}