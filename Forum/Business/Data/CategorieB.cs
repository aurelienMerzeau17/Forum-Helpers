using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Business.Data
{
    public class CategorieB
    {
        public long Sujet_id { get; set; }
        public long Forum_id { get; set; }
        public string Nom { get; set; }
    }
}