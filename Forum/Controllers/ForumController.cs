using Forum.Business;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Forum.Controllers
{
    /// <summary>
    /// Available method for the forums
    /// </summary>
    public class ForumController : ApiController
    {

        /// <summary>
        /// Get an array of all forum informations
        /// </summary>
        /// <returns>Array</returns>
        [HttpGet]
        [Route("api/Forums")]
        public List<ForumModel> GetListForum()
        {
            ForumBusiness forum = new ForumBusiness();
            return ConvertModel.ToModel(forum.GetListForum());
        }

        /// <summary>
        /// Get a forum information by id
        /// </summary>
        /// <param name="IDForum">forum id</param>
        /// <returns>ForumModel Forum</returns>       
        [HttpGet]
        [Route("api/Forum/{IDForum}")]
         public ForumModel GetForum(int IDForum)
        {
            ForumBusiness forum = new ForumBusiness();
            return ConvertModel.ToModel(forum.GetForum(IDForum));
        }

        /// <summary>
        /// Create a forum with his name
        /// </summary>
        /// <param name="forum">forum Model</param>
        [HttpPost]
        [Route("api/Forum")]
        public bool CreateForum(ForumModel forum)
        {
            /*ForumModel NewForum = new ForumModel();
            NewForum.Nom = Name;
            NewForum.Url = string.Empty;
            ForumBusiness forum = new ForumBusiness();
            forum.CreateForum(ConvertModel.ToBusiness(NewForum));*/
            return true;
        }

        /// <summary>
        /// Edit a forum by id
        /// </summary>
        /// <param name="forum">forumModel</param>
        [HttpPost]
        [Route("api/Forum/{id}")]
        public bool EditForum(ForumModel forum)
        {
            return true;
        }

        /// <summary>
        /// Delete a forum by id
        /// </summary>
        /// <param name="IDForum">forum id</param>
        [HttpDelete]
        [Route("api/Forum/{IDForum}")]
        public bool DeleteForum(int IDForum)
        {
            return true;
        }
    }
}