using AutoMapper;
using Forum.Business.Data;
using Forum.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Business
{
    public static class ConvertBusiness
    {
        //TO BUSINESS
        public static ForumB ToBusiness(ForumD forum)
        {
            Mapper.CreateMap<ForumD, ForumB>();
            return Mapper.Map<ForumD, ForumB>(forum);
        }

        public static TopicB ToBusiness(TopicD topic)
        {
            Mapper.CreateMap<TopicD,TopicB>();
            return Mapper.Map<TopicD, TopicB>(topic);
        }

        public static List<CategorieB> ToBusiness(List<CategorieD> category)
        {
            List<CategorieB> listCatb = new List<CategorieB>();
            Mapper.CreateMap<CategorieD, CategorieB>();

            foreach (var cat in category)
            {
                listCatb.Add(Mapper.Map<CategorieD, CategorieB>(cat));
            }
            return listCatb;
        }

        public static MessageB ToBusiness(MessageD message)
        {
            Mapper.CreateMap<MessageD, MessageB>();
            return Mapper.Map<MessageD, MessageB>(message);
        }

        //TO BUSINESS LIST
        public static List<ForumB> ToBusiness(List<ForumD> listforumd)
        {
            List<ForumB> listforumb = new List<ForumB>();
            Mapper.CreateMap<ForumD, ForumB>();

            foreach (var forumb in listforumd)
            {
                listforumb.Add(Mapper.Map<ForumD, ForumB>(forumb));
            }
            return listforumb;
        }

        //TO DAL
        public static ForumD ToDAL(ForumB forum)
        {
            Mapper.CreateMap<ForumB, ForumD>();
            return Mapper.Map<ForumB, ForumD>(forum);
        }

        public static TopicD ToDAL(TopicB topic)
        {
            Mapper.CreateMap<TopicB, TopicD>();
            return Mapper.Map<TopicB, TopicD>(topic);
        }

        public static CategorieD ToDAL(CategorieB categoy)
        {
            Mapper.CreateMap<CategorieB, CategorieD>();
            return Mapper.Map<CategorieB, CategorieD>(categoy);
        }

        public static MessageD ToDAL(MessageB message)
        {
            Mapper.CreateMap<MessageB, MessageD>();
            return Mapper.Map<MessageB, MessageD>(message);
        }

        internal static CategorieB ToBusiness(CategorieD categorieD)
        {
            Mapper.CreateMap<CategorieD, CategorieB>();
            return Mapper.Map<CategorieD, CategorieB>(categorieD);            
        }

        internal static List<TopicB> ToBusiness(List<TopicD> listtopicd)
        {
            List<TopicB> listtopicb = new List<TopicB>();
            Mapper.CreateMap<TopicD, TopicB>();

            foreach (var topicb in listtopicd)
            {
                listtopicb.Add(Mapper.Map<TopicD, TopicB>(topicb));
            }
            return listtopicb;
        }

        internal static List<MessageB> ToBusiness(List<MessageD> list)
        {

            List<MessageB> listMesb = new List<MessageB>();
            Mapper.CreateMap<MessageD, MessageB>();

            foreach (var mes in list)
            {
                listMesb.Add(Mapper.Map<MessageD, MessageB>(mes));
            }
            return listMesb;
        }
    }
}