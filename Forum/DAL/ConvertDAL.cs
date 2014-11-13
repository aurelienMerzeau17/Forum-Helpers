using AutoMapper;
using Forum.Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public static class ConvertModel
    {
        public static TopicModel ToModel (TopicB topic)
    {
            Mapper.CreateMap<TopicB, TopicModel>();
            return Mapper.Map<TopicB, TopicModel>(topic);
        }
    }
}
