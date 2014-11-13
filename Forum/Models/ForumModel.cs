using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.Models
{
    /// <summary>
    /// Forum Model
    /// </summary>
    public class ForumModel
    {
        public long Forum_id { get; set; }
        public string Nom { get; set; }
        public string Url { get; set; }
    }
}
