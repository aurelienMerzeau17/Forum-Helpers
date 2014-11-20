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
    public class MessageDAL
    {
        public bool CreateMessage(MessageD mes)
        {
            using (ps_FOR_GetMessageTableAdapter MessageDal = new ps_FOR_GetMessageTableAdapter())
            {
                MessageDal.ps_FOR_CreateMessage(mes.Topic_id, mes.Utilisateur_id,mes.DatePoste,mes.ContenuMessage);
            }
                return true;
        }

        public bool EditMessage(MessageD mes)
        {
            using (ps_FOR_GetMessageTableAdapter MessageDal = new ps_FOR_GetMessageTableAdapter())
            {
                MessageDal.ps_FOR_UpdateMessage(mes.Message_id, mes.ContenuMessage);
            }
            return true;
        }

        public bool DeleteMessage(int id)
        {
            using (ps_FOR_GetMessageTableAdapter MessageDal = new ps_FOR_GetMessageTableAdapter())
            {
                MessageDal.ps_FOR_DeleteMessage(id);
            }
            return true;
        }

        public List<MessageD> GetListTopicMessage(int idTopic)
        {
            myDataSet.ps_FOR_GetMessageDataTable datatable;

            using (ps_FOR_GetMessageTableAdapter MessageDal = new ps_FOR_GetMessageTableAdapter())
            {
                datatable = MessageDal.ps_FOR_GetListTopicMessage(idTopic);
            }
            return MessageMappeur.ToMessageD(datatable).ToList();
        }

        public List<MessageD> GetListUserMessage(int idUser)
        {
            myDataSet.ps_FOR_GetMessageDataTable datatable;

            using (ps_FOR_GetMessageTableAdapter MessageDal = new ps_FOR_GetMessageTableAdapter())
            {
                datatable = MessageDal.ps_FOR_GetListUserMessage( idUser);
            }
            return MessageMappeur.ToMessageD(datatable).ToList();
        }

        public List<MessageD> GetListMessage()
        {

            myDataSet.ps_FOR_GetMessageDataTable datatable;
            using (ps_FOR_GetMessageTableAdapter MessageDal = new ps_FOR_GetMessageTableAdapter())
            {
                datatable = MessageDal.ps_FOR_GetListMessage();
            }
            return MessageMappeur.ToMessageD(datatable).ToList();
        }

        public MessageD GetMessage(int id)
        {
            {
                myDataSet.ps_FOR_GetMessageDataTable datatable;
                using (ps_FOR_GetMessageTableAdapter MessageDal = new ps_FOR_GetMessageTableAdapter())
                {
                    datatable = MessageDal.ps_FOR_GetMessage(id);
                }
                return MessageMappeur.ToMessageD(datatable).ElementAt(0);
            }
        }

        public bool ReportMessage(int id)
        {
            using (ps_FOR_GetMessageTableAdapter MessageDal = new ps_FOR_GetMessageTableAdapter())
            {
                MessageDal.ps_FOR_ReportMessage(id);
            }
            return true;
        }

        internal List<MessageD> GetListReportMessage()
        {
            myDataSet.ps_FOR_GetMessageDataTable datatable;
            using (ps_FOR_GetMessageTableAdapter MessageDal = new ps_FOR_GetMessageTableAdapter())
            {
                datatable = MessageDal.ps_FOR_GetListReportMessage();
            }
            return MessageMappeur.ToMessageD(datatable).ToList();
        }

        internal bool UnReportMessage(int IDMessage)
        {
            using (ps_FOR_GetMessageTableAdapter MessageDal = new ps_FOR_GetMessageTableAdapter())
            {
                MessageDal.ps_FOR_UnReportMessage(IDMessage);
            }
            return true;
        }
    }
}