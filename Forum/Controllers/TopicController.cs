using Forum.Business;
using Forum.Models;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Forum.Controllers
{
    /// <summary>
    /// Available method for topics
    /// </summary>
    public class TopicController : ApiController
    {
        string urlLogger = "http://loggerasp.azurewebsites.net/";

        /// <summary>
        /// Get an array of all topic informations
        /// </summary>
        /// <returns>Array ListTopicModel</returns>
        [HttpGet]
        [Route("api/Topics")]
        public List<TopicModel> GetListTopic()
        {
            try
            {
                TopicBusiness topic = new TopicBusiness();
                return ConvertModel.ToModel(topic.GetListTopic());
            }
            catch (Exception e)
            {
                new LErreur(e, "Forum", "GetListTopic", 5).Save(urlLogger);
                return null;
            }
        }

        /// <summary>
        /// Get a topic information by id
        /// </summary>
        /// <param name="id">topic id</param>
        /// <returns>Array TopicModel</returns>
        [HttpGet]
        [Route("api/Topic/{id}")]
        public TopicModel GetTopic(int id)
        {
            try
            {
                TopicBusiness topic = new TopicBusiness();
                return ConvertModel.ToModel(topic.GetTopic(id));
            }
            catch (Exception e)
            {
                new LErreur(e, "Forum", "GetTopic", 5).Save(urlLogger);
                return null;
            }
        }



        /// <summary>
        /// Get a topic information by Category id
        /// </summary>
        /// <param name="IDCategory">event id</param>
        /// <returns>Array TopicModel</returns>
        [HttpGet]
        [Route("api/TopicCategory/{IDCategory}")]
        public List<TopicModel> GetTopicByCategory(int IDCategory)
        {
            try
            {
                TopicBusiness topic = new TopicBusiness();
                return ConvertModel.ToModel(topic.GetTopicByCategory(IDCategory));
            }
            catch (Exception e)
            {
                new LErreur(e, "Forum", "GetTopicByCategory", 5).Save(urlLogger);
                return null;
            }
        }

        /// <summary>
        /// Create a topic 
        /// </summary>
        /// <param name="TopM">TopicModel</param>
        [HttpPost]
        [Route("api/Topic")]
        public int CreateTopic(TopicModel TopM)
        {
            try
            {
                TopicBusiness Top = new TopicBusiness();
                return Top.CreateTopic(ConvertModel.ToBusiness(TopM));
            }
            catch (Exception e)
            {
                new LErreur(e, "Forum", "CreateTopic", 5).Save(urlLogger);
                return -1;
            }
        }

        ///// <summary>
        ///// Edit a topic by id and the changed text
        ///// </summary>
        ///// <param name="Top">TopicModel</param>
        //[HttpPost]
        //[Route("api/Topic/{id}")]
        //public bool EditTopic(TopicModel Top)
        //{
        //    TopicBusiness TopicM = new TopicBusiness();
        //    return TopicM.EditTopic(ConvertModel.ToBusiness(Top));
        //}

        ///// <summary>
        ///// Delete topic by id
        ///// </summary>
        ///// <param name="IDTopic">topic id</param>
        //[HttpDelete]
        //[Route("api/Topic/{IDTopic}")]
        //public bool DeleteTopic(int IDTopic)
        //{
        //    TopicBusiness topicB = new TopicBusiness();
        //    return topicB.DeleteTopic(IDTopic);
        //}
    }
}