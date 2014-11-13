using Forum.DAL;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Forum.DAL.Data;
using Forum.Business.Data;

namespace Forum.Business
{
    public class ForumBusiness
    {

        public ForumB GetForum(int id)
        {
            ForumDAL forum = new ForumDAL();
            return ConvertBusiness.ToBusiness(forum.GetForum(id));
        }

        public bool EditForum(ForumB forum)
        {
            ForumDAL forumD = new ForumDAL();
            return forumD.EditForum(ConvertBusiness.ToDAL(forum));
        }

        public List<ForumB> GetListForum()
        {
            ForumDAL forum = new ForumDAL();
            return ConvertBusiness.ToBusiness(forum.GetListForum());
        }

        public bool CreateForum(ForumB forB)
        {
            ForumDAL forumD = new ForumDAL();
            return forumD.CreateForum(ConvertBusiness.ToDAL(forB));
        }

        public bool DeleteForum(int id)
        {
            ForumDAL forumD = new ForumDAL();
            return forumD.DeleteForum(id);
        }
    }
}