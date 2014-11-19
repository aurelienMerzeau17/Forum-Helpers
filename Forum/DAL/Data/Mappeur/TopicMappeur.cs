using System;
using System.Collections.Generic;
using System.Linq;
using TopicTable = Forum.myDataSet.ps_FOR_GetTopicDataTable;
using TopicRow = Forum.myDataSet.ps_FOR_GetTopicRow;
using System.Web;

namespace Forum.DAL.Data.Mappeur
{
    public static class TopicMappeur
    {
        public static IEnumerable<TopicD> ToTopicD(this TopicTable table)
        {
            List<TopicD> list = new List<TopicD>();
            foreach (TopicRow item in table.Rows)
            {
                list.Add(ToTopicD(item));
            }
            return list;
        }
        public static TopicD ToTopicD(this TopicRow row)
        {
            TopicD d = new TopicD();
            d.Topic_id = row.Topic_id;
            d.Sujet_id = row.Sujet_id;
            d.Nom = row.Nom;
            d.DescriptifTopic = row.DescriptifTopic;
            d.DateCreation = row.DateCreation;
            d.Resolu = row.Resolu;
            d.Utilisateur_id = row.Utilisateur_id;

            return d;
        }
    }
}