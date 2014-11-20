using System;
using System.Collections.Generic;
using System.Linq;
using MessageTable = Forum.myDataSet.ps_FOR_GetMessageDataTable;
using MessageRow = Forum.myDataSet.ps_FOR_GetMessageRow;
using System.Web;

namespace Forum.DAL.Data.Mappeur
{
    public static class MessageMappeur
    {
        public static IEnumerable<MessageD> ToMessageD(this MessageTable table)
        {
            List<MessageD> list = new List<MessageD>();
            foreach(MessageRow item in table.Rows)
            {
                list.Add(ToMessageD(item));
            }
            return list;
        }
        public static MessageD ToMessageD(this MessageRow row)
        {
            MessageD d = new MessageD();
            d.Message_id = row.Message_id;
            d.Topic_id = row.Topic_id;
            d.Utilisateur_id = row.Utilisateur_id;
            d.DatePoste = row.DatePoste;
            d.ContenuMessage = row.ContenuMessage;
            d.Report = row.Report;

            return d;
        }
    }
}