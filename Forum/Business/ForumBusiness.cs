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
            CategorieBusiness cat = new CategorieBusiness();
            List<CategorieB> listCatB = cat.GetListCategorieForum(id);

            foreach(CategorieB c in listCatB)
            {
                TopicBusiness top = new TopicBusiness();
                List<TopicB> listTopB = top.GetTopicByCategory(Convert.ToInt32(c.Sujet_id));

                foreach(TopicB t in listTopB)
                {
                    MessageBusiness mes = new MessageBusiness();
                    List<MessageB> listMesB = mes.GetListTopicMessage(Convert.ToInt32(t.Topic_id));

                    foreach(MessageB m in listMesB)
                    {
                        mes.DeleteMessage(Convert.ToInt32(m.Message_id));
                    }
                    top.DeleteTopic(Convert.ToInt32(t.Topic_id));
                }
                cat.DeleteCategorie(Convert.ToInt32(c.Sujet_id));
            }
            ForumDAL forumD = new ForumDAL();
            return forumD.DeleteForum(id);
        }
    }
}