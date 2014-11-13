using Forum.DAL.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Forum.DAL
{
    public class ForumDAL
    {
        string connexionstring = "data source=avip9np4yy.database.windows.net,1433;initial catalog=YoupDEV;persist security info=True;user id=youpDEV;password=youpD3VASP*;MultipleActiveResultSets=True;App=EntityFramework";
        SqlConnection myConnection;
        public ForumDAL()
        {
            myConnection = new SqlConnection(connexionstring);
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public bool CreateForum(ForumD forum)
        {
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = myConnection;
                    command.CommandText = "INSERT INTO FOR_Forum (Forum_id, Nom, Url) "
                        + "Values (" + forum.Forum_id + ", '" + forum.Nom + "', '" + forum.Url + "')";
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditForum(ForumD forum)
        {
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = myConnection;
                    command.CommandText = "UPDATE FOR_Forum SET Nom = '" + forum.Nom + "', Url = '" + forum.Url + "' WHERE Forum_id = " + forum.Forum_id;
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteForum(int id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = myConnection;
                    command.CommandText = "DELETE FROM FOR_Forum WHERE Forum_id = " + id;
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ForumD> GetListForum()
        {
            List<ForumD> ListF = new List<ForumD>();
            using (SqlCommand command = new SqlCommand("SELECT * FROM FOR_Forum", myConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListF.Add(new ForumD
                        {
                            Forum_id = Convert.ToInt32(reader["Forum_id"]),
                            Nom = reader["Nom"].ToString(),
                            Url = reader["Url"].ToString()
                        });
                    }
                }
            }
            return ListF;
        }

        public ForumD GetForum(int id)
        {
            ForumD forum = new ForumD();
            using (SqlCommand command = new SqlCommand("SELECT * FROM FOR_Forum WHERE Forum_id = " + id, myConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        forum.Nom = reader["Nom"].ToString();
                        forum.Url = reader["Url"].ToString();
                    }
                }
            }
            return forum;
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
    }
}