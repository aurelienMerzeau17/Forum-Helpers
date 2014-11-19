using Forum.Business;
using Forum.Models;
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
            catch
            {
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
            catch
            {
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
            catch
            {
                return null;
            }
        }

        ////////////////////////////////////////////////////////////////////////
        //probleme contrainte sql
        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Create a topic 
        /// </summary>
        /// <param name="TopM">TopicModel</param>
        [HttpPost]
        [Route("api/Topic")]
        public int CreateTopic(TopicModel TopM)
        {
            TopicBusiness Top = new TopicBusiness();
            return Top.CreateTopic(ConvertModel.ToBusiness(TopM));
        }

        /// <summary>
        /// Edit a topic by id and the changed text
        /// </summary>
        /// <param name="Top">TopicModel</param>
        [HttpPost]
        [Route("api/Topic/{id}")]
        public bool EditTopic(TopicModel Top)
        {
            TopicBusiness TopicM = new TopicBusiness();
            return TopicM.EditTopic(ConvertModel.ToBusiness(Top));
        }

        /// <summary>
        /// Delete topic by id
        /// </summary>
        /// <param name="IDTopic">topic id</param>
        [HttpDelete]
        [Route("api/Topic/{IDTopic}")]
        public bool DeleteTopic(int IDTopic)
        {
            TopicBusiness topicB = new TopicBusiness();
            return topicB.DeleteTopic(IDTopic);
        }
    }
}