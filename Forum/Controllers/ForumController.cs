using Forum.Business;
using Forum.Models;
using Logger;
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
        string urlLogger = "http://loggerasp.azurewebsites.net/";

        /// <summary>
        /// Get an array of all forum informations
        /// </summary>
        /// <returns>Array</returns>
        [HttpGet]
        [Route("api/Forums")]
        public List<ForumModel> GetListForum()
        {
            try
            {
                ForumBusiness forum = new ForumBusiness();
                return ConvertModel.ToModel(forum.GetListForum());
            }
            catch (Exception e)
            {
                new LErreur(e, "Forum", "GetTopicByCategory", 5).Save(urlLogger);
                return null;
            }
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
            try
            {
                ForumBusiness forum = new ForumBusiness();
                return ConvertModel.ToModel(forum.GetForum(IDForum));
            }
            catch (Exception e)
            {
                new LErreur(e, "Forum", "GetTopicByCategory", 5).Save(urlLogger);
                return null;
            }
        }

        ///// <summary>
        ///// Create a forum with his name
        ///// </summary>
        ///// <param name="forum">forum Model</param>
        //[HttpPost]
        //[Route("api/Forum")]
        //public bool CreateForum(ForumModel forum)
        //{
        //    ForumBusiness forumB = new ForumBusiness();
        //    forumB.CreateForum(ConvertModel.ToBusiness(forum));
        //    return true;
        //}

        ///// <summary>
        ///// Edit a forum by id
        ///// </summary>
        ///// <param name="forum">forumModel</param>
        //[HttpPost]
        //[Route("api/Forum/{id}")]
        //public bool EditForum(ForumModel forum)
        //{
        //    ForumBusiness forumB = new ForumBusiness();
        //    forumB.EditForum(ConvertModel.ToBusiness(forum));
        //    return true;
        //}

        ///// <summary>
        ///// Delete a forum by id
        ///// </summary>
        ///// <param name="IDForum">forum id</param>
        //[HttpDelete]
        //[Route("api/Forum/{IDForum}")]
        //public bool DeleteForum(int IDForum)
        //{
        //    ForumBusiness forumB = new ForumBusiness();
        //    forumB.DeleteForum(IDForum);
        //    return true;
        //}
    }
}