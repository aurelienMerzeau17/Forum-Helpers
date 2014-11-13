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
        public TopicB getTopic(int id)
        {

            TopicDAL topicD = new TopicDAL();
            return ConvertBusiness.ToBusiness(topicD.GetTopic(id));
        }
        public bool EditTopic(TopicB topic)
        {
            TopicDAL TopicD = new TopicDAL();
            return TopicD.EditTopic(ConvertBusiness.ToDAL(topic));          
        }
        public List<TopicB> GetListTopic()
        {

            TopicDAL topicD = new TopicDAL();
            // TODO
            return ConvertBusiness.ToBusiness(topicD.GetListTopic());
        }
       /* public TopicModel GetTopicByEvent()
        {
            TopicDAL topicdal = new TopicDAL();
            return ConvertBusiness.ToBusiness(topicdal.GetTopicByEvent());

        }*/
        public bool CreateTopic(TopicB topB)
        {
            TopicDAL topicD = new TopicDAL();
            return topicD.EditTopic(ConvertBusiness.ToDAL(topB));
        }
        public bool DeleteTopic(int id)
        {
            TopicDAL topicD = new TopicDAL();
            return topicD.DeleteTopic(id);
        }


    }
}