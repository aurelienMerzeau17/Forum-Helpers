using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.DAL.Data
{
    public class TopicD
    {
        public long Topic_id { get; set; }
        public long Sujet_id { get; set; }
        public string Nom { get; set; }
        public string DescriptifTopic { get; set; }
        public System.DateTime DateCreation { get; set; }
        public bool Resolu { get; set; }
        public long Utilisateur_id { get; set; }
    }
}