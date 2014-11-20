using Forum.Business.Data;
using Forum.DAL;
using Forum.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Business
{
    public class MessageBusiness
    {
        public MessageB getMessage(int id)
        {
            MessageDAL message = new MessageDAL();
            return ConvertBusiness.ToBusiness(message.GetMessage(id));
        }
        public bool EditMessage(MessageB mes)
        {
            MessageDAL messagedal = new MessageDAL();
            return messagedal.EditMessage(ConvertBusiness.ToDAL(mes));
        }

        //permet de creer un message 
        public bool CreateMessage(MessageB mes)
        {
            MessageDAL message = new MessageDAL();
            return message.CreateMessage(ConvertBusiness.ToDAL(mes));
        }

        //récupère une liste de topic
        public List<MessageB> GetListTopicMessage(int idTopic)
        {
            MessageDAL message = new MessageDAL();
            return ConvertBusiness.ToBusiness(message.GetListTopicMessage(idTopic));

            
        }

        public List<MessageB> GetListUserMessage(int idUser)
        {
            MessageDAL message = new MessageDAL();
            return ConvertBusiness.ToBusiness(message.GetListUserMessage(idUser));
        }

        public List<MessageB> GetListMessage()
        {
            MessageDAL message = new MessageDAL();
            return ConvertBusiness.ToBusiness(message.GetListMessage());
        }

        public bool DeleteMessage(int id)
        {
            MessageDAL message = new MessageDAL();
            return message.DeleteMessage(id);
        }

        internal List<MessageB> GetListReportMessage()
        {
            MessageDAL message = new MessageDAL();
            return ConvertBusiness.ToBusiness(message.GetListReportMessage());
        }

        internal bool ReportMessage(int IDMessage)
        {
            MessageDAL message = new MessageDAL();
            return message.ReportMessage(IDMessage);
        }

        internal bool UnReportMessage(int IDMessage)
        {
            MessageDAL message = new MessageDAL();
            return message.UnReportMessage(IDMessage);
        }
    }
}