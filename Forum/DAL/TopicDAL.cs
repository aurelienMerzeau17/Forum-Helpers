using Forum.DAL.Data;
using Forum.DAL.Data.Mappeur;
using Forum.myDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Forum.DAL
{
    public class TopicDAL
    {
        public int CreateTopic(TopicD top)
        {
            int topic_id;
            using (ps_FOR_GetTopicTableAdapter TopicTable = new ps_FOR_GetTopicTableAdapter())
            {
                topic_id = (int)TopicTable.ps_FOR_CreateTopic(top.Sujet_id, top.Nom, top.DescriptifTopic, top.DateCreation, top.Resolu, top.Utilisateur_id);
            }
            return topic_id;
        }

        public bool EditTopic(TopicD top)
        {
            using (ps_FOR_GetTopicTableAdapter TopicTable = new ps_FOR_GetTopicTableAdapter())
            {
                TopicTable.ps_FOR_UpdateTopic(top.Nom, top.DescriptifTopic, top.Resolu, top.Topic_id);
            }
            return true;
        }

        public bool DeleteTopic(int id)
        {
            using (ps_FOR_GetTopicTableAdapter TopicTable = new ps_FOR_GetTopicTableAdapter())
            {
                TopicTable.ps_FOR_DeleteTopic(id);
            }
            return true;
        }

        public List<TopicD> GetListTopic()
        {
            myDataSet.ps_FOR_GetTopicDataTable datatable;
            using (ps_FOR_GetTopicTableAdapter TopicTable = new ps_FOR_GetTopicTableAdapter())
            {
                datatable = TopicTable.ps_FOR_GetListTopic();
            }
            return TopicMappeur.ToTopicD(datatable).ToList();
        }

        public TopicD GetTopic(int id)
        {
            myDataSet.ps_FOR_GetTopicDataTable datatable;
            using (ps_FOR_GetTopicTableAdapter TopicDal = new ps_FOR_GetTopicTableAdapter())
            {
                datatable = TopicDal.ps_FOR_GetTopic(id);
            }
            return TopicMappeur.ToTopicD(datatable).ElementAt(0);
        }

        internal List<TopicD> GetTopicByCategory(int IDCategory)
        {
            myDataSet.ps_FOR_GetTopicDataTable datatable;

            using (ps_FOR_GetTopicTableAdapter TopicTable = new ps_FOR_GetTopicTableAdapter())
            {
                datatable = TopicTable.ps_FOR_GetListTopicByCategorie(IDCategory);
            }
            return TopicMappeur.ToTopicD(datatable).ToList();
        }
    }
}