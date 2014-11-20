using Forum.Business.Data;
using Forum.DAL;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Business
{
    public class TopicBusiness
    {
        public TopicB GetTopic(int id)
        {

            TopicDAL topicD = new TopicDAL();
            return ConvertBusiness.ToBusiness(topicD.GetTopic(id));
        }
        public bool EditTopic(TopicB Top)
        {
            TopicDAL TopicD = new TopicDAL();
            return TopicD.EditTopic(ConvertBusiness.ToDAL(Top));          
        }
        public List<TopicB> GetListTopic()
        {
            TopicDAL topicD = new TopicDAL();
            return ConvertBusiness.ToBusiness(topicD.GetListTopic());
        }
       
        public int CreateTopic(TopicB Top)
        {
            TopicDAL topicD = new TopicDAL();
            return topicD.CreateTopic(ConvertBusiness.ToDAL(Top));
        }
        public bool DeleteTopic(int id)
        {
            MessageBusiness mes = new MessageBusiness();
            List<MessageB> listMesB = mes.GetListTopicMessage(Convert.ToInt32(id));

            foreach (MessageB m in listMesB)
            {
                mes.DeleteMessage(Convert.ToInt32(m.Message_id));
            }

            TopicDAL topicD = new TopicDAL();
            return topicD.DeleteTopic(id);
        }

        
        public List<TopicB> GetTopicByCategory(int idCategorie)
        {
            TopicDAL topicdal = new TopicDAL();
            return ConvertBusiness.ToBusiness(topicdal.GetTopicByCategory(idCategorie));
        }

        internal TopicB GetTopicByEvent(int IDEvent)
        {
            throw new NotImplementedException();
        }
    }
}