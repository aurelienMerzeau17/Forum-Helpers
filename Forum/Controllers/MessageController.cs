using Forum.Business;
using Forum.Models;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestSharp;

namespace Forum.Controllers
{
    /// <summary>
    /// Available method for messages
    /// </summary>
    public class MessageController : ApiController
    {

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient("http://aspmoduleprofil.azurewebsites.net/");
            var response = client.Execute<T>(request);
            return response.Data;
        }


        /// <summary>
        /// get a small user by id
        /// </summary>
        /// <param name="id"> user id</param>
        /// <returns>UserSmallModel</returns>
        [HttpGet]
        [Route("api/GetSmallUserById")]
        public UserSmallModel GetUserById(int id)
        {
            var request = new RestRequest("api/UserSmall/" + id, Method.GET);
            var result = Execute<UserSmallModel>(request);

            return result;
        }


        /// <summary>
        /// Post a message to research api
        /// </summary>
        /// <param name="Message">MessageModel</param>
        /// <param name="pseudo">Pseudo of the user who post the message</param>
        /// <returns>boolean</returns>
        [HttpPost]
        [Route("api/PostMesstoResearch")]
        public bool PostMess(MessageModel Message, string pseudo)
        {
            var client = new RestClient("http://youp-recherche.azurewebsites.net/");
            RestRequest request = new RestRequest("add/get_postforum?id=" + Message.Message_id + "&date=" + Message.DatePoste + "&author=" + pseudo, Method.GET);
            var result = client.Execute<bool>(request);
            return result.Data;
        }


        string urlLogger = "http://loggerasp.azurewebsites.net/";

        /// <summary>
        /// Get an array of all messages in a topic
        /// </summary>
        /// <param name="IDTopic">topic id</param>
        /// <returns>Array ListMessageModel</returns>
        [HttpGet]
        [Route("api/Messages")]
        public List<MessageModel> GetListMessage()
        {
            try
            {
                MessageBusiness messageB = new MessageBusiness();
                return ConvertModel.ToModel(messageB.GetListMessage());
            }
            catch (Exception e)
            {
                new LErreur(e, "Forum", "GetListMessage", 5).Save(urlLogger);
                return null;
            }
        }

        /// <summary>
        /// Get an array of all user's messages
        /// </summary>
        /// <param name="IDUser">user id</param>
        /// <returns>Array</returns>
        [HttpGet]
        [Route("api/MessageUser/{IDUser}")]
        public List<MessageModel> GetListMessageByUser(int IDUser)
        {
            try
            {
                MessageBusiness messageb = new MessageBusiness();
                return ConvertModel.ToModel(messageb.GetListUserMessage(IDUser));
            }
            catch (Exception e)
            {
                new LErreur(e, "Forum", "GetListMessageByUser", 5).Save(urlLogger);
                return null;
            }
        }

        /// <summary>
        /// Get a message information by id
        /// </summary>
        ///         
        /// <param name="IDMessage">message id</param>
        /// <returns>Array MessageModel</returns>
        [HttpGet]
        [Route("api/Message/{IDMessage}")]
        public MessageModel GetMessage(int IDMessage)
        {
            try
            {
                MessageBusiness messageb = new MessageBusiness();
                return ConvertModel.ToModel(messageb.getMessage(IDMessage));
            }
            catch (Exception e)
            {
                new LErreur(e, "Forum", "GetMessage", 5).Save(urlLogger);
                return null;
            }
        }

        /// <summary>
        /// Create an new message with his content
        /// </summary>
        /// <param name="Message">message content</param>
        [HttpPost]
        [Route("api/Message")]
        public bool CreateMessage(MessageModel Message)
        {
            try
            {
                MessageBusiness messageb = new MessageBusiness();
                bool retour = messageb.CreateMessage(ConvertModel.ToBusiness(Message));

                UserSmallModel user = this.GetUserById(Convert.ToInt32(Message.Utilisateur_id));
                MessageModel mes = ConvertModel.ToModel(messageb.GetListMessage().OrderBy(o => o.Message_id).LastOrDefault());
                bool postmes = this.PostMess(mes, user.Pseudo);

                return retour & postmes;
            }
            catch (Exception e)
            {
                new LErreur(e, "Forum", "CreateMessage", 5).Save(urlLogger);
                return false;
            }
        }

        ///// <summary>
        ///// Edit message by message and the changed text
        ///// </summary>
        ///// <param name="mes">message content</param>
        //[HttpPost]
        //[Route("api/Message/{id}")]
        //public bool EditMessage(MessageModel mes)
        //{
        //    try
        //    {
        //        MessageBusiness messageb = new MessageBusiness();
        //        return messageb.EditMessage(ConvertModel.ToBusiness(mes));
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// Delete a message by id
        ///// </summary>
        ///// <param name="IDMessage">message id</param>
        //[HttpDelete]
        //[Route("api/Message/{IDMessage}")]
        //public bool DeleteMessage(int IDMessage)
        //{
        //    try
        //    {
        //        MessageBusiness messageb = new MessageBusiness();
        //        return messageb.DeleteMessage(IDMessage);
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        /// <summary>
        /// Get an array of all Topic's messages
        /// </summary>
        /// <param name="IDTopic">Topic id</param>
        [HttpGet]
        [Route("api/MessageTopic/{IDTopic}")]
        public List<MessageModel> GetListTopicMessage(int IDTopic)
        {
            try
            {
                MessageBusiness messageb = new MessageBusiness();
                return ConvertModel.ToModel(messageb.GetListTopicMessage(IDTopic));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Report a message by id
        /// </summary>
        /// <param name="IDMessage">message id</param>
        [HttpGet]
        [Route("api/ReportMessage/{IDMessage}")]
        public bool ReportMessage(int IDMessage)
        {
            try
            {
                MessageBusiness messageb = new MessageBusiness();
                return messageb.ReportMessage(IDMessage);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// UnReport a message by id
        /// </summary>
        /// <param name="IDMessage">message id</param>
        [HttpGet]
        [Route("api/UnReportMessage/{IDMessage}")]
        public bool UnReportMessage(int IDMessage)
        {
            try
            {
                MessageBusiness messageb = new MessageBusiness();
                return messageb.UnReportMessage(IDMessage);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Get an array of all reported messages
        /// </summary>
        [HttpGet]
        [Route("api/ReportMessages")]
        public List<MessageModel> GetListReportMessage()
        {
            try
            {
                MessageBusiness messageb = new MessageBusiness();
                return ConvertModel.ToModel(messageb.GetListReportMessage());
            }
            catch
            {
                return null;
            }
        }
    }
}
