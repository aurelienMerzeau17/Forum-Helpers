using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Models;
using Forum.Business.Data;
using AutoMapper;

namespace BackOffice.Models
{
    public class ConvertModel
    {
        public static TopicModel ToModel(TopicB topic)
        {
            Mapper.CreateMap<TopicB, TopicModel>();
            return Mapper.Map<TopicB, TopicModel>(topic);
        }

        internal static List<TopicModel> ToModel(List<TopicB> list)
        {
            List<TopicModel> listtopicM = new List<TopicModel>();
            Mapper.CreateMap<TopicB, TopicModel>();
            foreach (var topicb in list)
            {
                listtopicM.Add(Mapper.Map<TopicB, TopicModel>(topicb));
            }
            return listtopicM;
        }

        internal static List<ForumModel> ToModel(List<ForumB> list)
        {
            List<ForumModel> listforumM = new List<ForumModel>();
            Mapper.CreateMap<ForumB, ForumModel>();

            foreach (var forumb in list)
            {
                listforumM.Add(Mapper.Map<ForumB, ForumModel>(forumb));
            }
            return listforumM;
        }


        internal static List<MessageModel> ToModel(List<MessageB> list)
        {
            List<MessageModel> listmessage = new List<MessageModel>();
            Mapper.CreateMap<MessageB, MessageModel>();

            foreach (var messagemodel in list)
            {
                listmessage.Add(Mapper.Map<MessageB, MessageModel>(messagemodel));
            }
            return listmessage;
        }

        internal static MessageModel ToModel(MessageB messageB)
        {
            Mapper.CreateMap<MessageB, MessageModel>();
            return Mapper.Map<MessageB, MessageModel>(messageB);
        }



        internal static MessageB ToBusiness(MessageModel Message)
        {
            Mapper.CreateMap<MessageModel, MessageB>();
            return Mapper.Map<MessageModel, MessageB>(Message);
        }

        internal static CategorieModel ToModel(CategorieB categorieb)
        {
            Mapper.CreateMap<CategorieB, CategorieModel>();
            return Mapper.Map<CategorieB, CategorieModel>(categorieb);
        }

        internal static List<CategorieModel> ToModel(List<CategorieB> list)
        {
            List<CategorieModel> listCatM = new List<CategorieModel>();
            Mapper.CreateMap<CategorieB, CategorieModel>();

            foreach (var catb in list)
            {
                listCatM.Add(Mapper.Map<CategorieB, CategorieModel>(catb));
            }
            return listCatM;
        }

        internal static ForumModel ToModel(ForumB forumB)
        {
            Mapper.CreateMap<ForumB, ForumModel>();
            return Mapper.Map<ForumB, ForumModel>(forumB);
        }

        internal static ForumB ToBusiness(ForumModel NewForum)
        {
            Mapper.CreateMap<ForumModel, ForumB>();
            return Mapper.Map<ForumModel, ForumB>(NewForum);
        }

        internal static CategorieB ToBusiness(CategorieModel cat)
        {
            Mapper.CreateMap<CategorieModel, CategorieB>();
            return Mapper.Map<CategorieModel, CategorieB>(cat);
        }
    }
}