using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class CategorieModel
    {
        public long Sujet_id { get; set; }
        public long Forum_id { get; set; } 
        public string Nom { get; set; }
    } 
}