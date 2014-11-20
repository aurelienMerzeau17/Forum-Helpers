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
    /// Available method for messages
    /// </summary>
    public class MessageController : ApiController
    {
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
                string sldplsd = null;
                sldplsd.IndexOf('r');
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
                return messageb.CreateMessage(ConvertModel.ToBusiness(Message));
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
