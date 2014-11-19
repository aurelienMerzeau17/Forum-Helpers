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
    /// Available method for messages
    /// </summary>
    public class MessageController : ApiController
    {
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
            catch
            {
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
            catch
            {
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
            catch
            {
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
            MessageBusiness messageb = new MessageBusiness();
            return messageb.CreateMessage(ConvertModel.ToBusiness(Message));

        }

        /// <summary>
        /// Edit message by message and the changed text
        /// </summary>
        /// <param name="mes">message content</param>
        [HttpPost]
        [Route("api/Message/{id}")]
        public bool EditMessage(MessageModel mes)
        {

            MessageBusiness messageb = new MessageBusiness();
            return messageb.EditMessage(ConvertModel.ToBusiness(mes));
        }

        /// <summary>
        /// Delete a message by id
        /// </summary>
        /// <param name="IDMessage">message id</param>
        [HttpDelete]
        [Route("api/Message/{IDMessage}")]
        public bool DeleteMessage(int IDMessage)
        {
            MessageBusiness messageb = new MessageBusiness();
            return messageb.DeleteMessage(IDMessage);

        }

        /// <summary>
        /// Get an array of all Topic's messages
        /// </summary>
        /// <param name="IDTopic">Topic id</param>
        [HttpGet]
        [Route("api/MessageTopic/{IDTopic}")]
        public List<MessageModel> GetListTopicMessage(int IDTopic)
        {

            MessageBusiness messageb = new MessageBusiness();
            return ConvertModel.ToModel(messageb.GetListTopicMessage(IDTopic));

        }

        /// <summary>
        /// Report a message by id
        /// </summary>
        /// <param name="IDMessage">message id</param>
        [HttpPost]
        [Route("api/ReportMessage/{IDMessage}")]
        public bool ReportMessage(int IDMessage)
        {
            return true;
        }
    }
}
