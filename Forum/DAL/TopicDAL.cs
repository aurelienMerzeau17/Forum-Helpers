using Forum.DAL.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Forum.DAL
{
    public class TopicDAL
    {
        string connexionstring = "data source=avip9np4yy.database.windows.net,1433;initial catalog=YoupDEV;persist security info=True;user id=youpDEV;password=youpD3VASP*;MultipleActiveResultSets=True;App=EntityFramework";
        SqlConnection myConnection;
        public TopicDAL()
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
        public bool CreateTopic(TopicD Top)
        {
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = myConnection;
                    command.CommandText = "INSERT INTO FOR_Topic (Topic_id, Sujet_id, Nom, DescriptifTopic, DateCreation, Resolu, Utilisateur_id) "
                        + "Values (" + Top.Topic_id + ", " + Top.Sujet_id + ", '" + Top.Nom + "', '" + Top.DescriptifTopic + "', '" + Top.DateCreation + "', " + Top.Resolu + ", " + Top.Utilisateur_id + ")";
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditTopic(TopicD Top)
        {
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = myConnection;
                    command.CommandText = "UPDATE FOR_Topic SET Nom = '" + Top.Nom + "', DescriptifTopic = '" + Top.DescriptifTopic + "', Resolu = " + Top.Resolu + " WHERE Topic_id = " + Top.Topic_id;
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTopic(int id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = myConnection;
                    command.CommandText = "DELETE FROM FOR_Topic WHERE Topic_id = " + id;
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TopicD> GetListTopic()
        {
            List<TopicD> ListT = new List<TopicD>();
            using (SqlCommand command = new SqlCommand("SELECT * FROM FOR_Topic", myConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListT.Add(new TopicD
                        {
                            Topic_id = Convert.ToInt32(reader["Topic_id"]),
                            Utilisateur_id = Convert.ToInt32(reader["Utilisateur_id"]),
                            Sujet_id = Convert.ToInt32(reader["Sujet_id"]),
                            Nom = reader["Nom"].ToString(),
                            DescriptifTopic = reader["DescriptifTopic"].ToString(),
                            DateCreation = Convert.ToDateTime(reader["DateCreation"]),
                            Resolu = Convert.ToBoolean(reader["Resolu"])
                        });
                    }
                }
            }
            return null;
        }

        public List<TopicD> GetListTopic(int Idcat)
        {
            List<TopicD> ListT = new List<TopicD>();
            using (SqlCommand command = new SqlCommand("SELECT * FROM FOR_Topic where Sujet_id =" + Idcat, myConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListT.Add(new TopicD
                        {
                            Topic_id = Convert.ToInt32(reader["Topic_id"]),
                            Utilisateur_id = Convert.ToInt32(reader["Utilisateur_id"]),
                            Sujet_id = Convert.ToInt32(reader["Sujet_id"]),
                            Nom = reader["Nom"].ToString(),
                            DescriptifTopic = reader["DescriptifTopic"].ToString(),
                            DateCreation = Convert.ToDateTime(reader["DateCreation"]),
                            Resolu = Convert.ToBoolean(reader["Resolu"])
                        });
                    }
                }
            }
            return null;
        }
        public TopicD GetTopic(int id)
        {
            TopicD top = new TopicD();
            using (SqlCommand command = new SqlCommand("SELECT * FROM FOR_Topic WHERE Topic_id = " + id, myConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        top.Topic_id = Convert.ToInt32(reader["Topic_id"]);
                        top.Utilisateur_id = Convert.ToInt32(reader["Utilisateur_id"]);
                        top.Sujet_id = Convert.ToInt32(reader["Sujet_id"]);
                        top.Nom = reader["Nom"].ToString();
                        top.DescriptifTopic = reader["DescriptifTopic"].ToString();
                        top.DateCreation = Convert.ToDateTime(reader["DateCreation"]);
                        top.Resolu = Convert.ToBoolean(reader["Resolu"]);
                    }
                }
            }
            return null;
        }

        /*public TopicD GetTopicByEvent(int idEvent)//A completer, pas moyen de Récupérer un topic en passant par un evenement avec la bdd actuelle
        {
            TopicD top = new TopicD();
            using (SqlCommand command = new SqlCommand("SELECT * FROM FOR_Topic WHERE Evenement_id", myConnection)) 
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        top.Topic_id = Convert.ToInt32(reader["Topic_id"]);
                        top.Utilisateur_id = Convert.ToInt32(reader["Utilisateur_id"]);
                        top.Sujet_id = Convert.ToInt32(reader["Sujet_id"]);
                        top.Nom = reader["Nom"].ToString();
                        top.DescriptifTopic = reader["DescriptifTopic"].ToString();
                        top.DateCreation = Convert.ToDateTime(reader["DateCreation"]);
                        top.Resolu = Convert.ToBoolean(reader["Resolu"]);
                    }
                }
            }
            return null;
        }*/

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