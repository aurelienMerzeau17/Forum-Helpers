using System;
using System.Collections.Generic;
using System.Linq;
using ForumTable = Forum.myDataSet.ps_FOR_GetForumDataTable;
using ForumRow = Forum.myDataSet.ps_FOR_GetForumRow;
using System.Web;

namespace Forum.DAL.Data.Mappeur
{
    public static class ForumMappeur
    {
        public static IEnumerable<ForumD> ToForumD(this ForumTable table)
        {
            List<ForumD> list = new List<ForumD>();
            foreach (ForumRow item in table.Rows)
            {
                list.Add(ToForumD(item));
            }
            return list;
        }
        public static ForumD ToForumD(this ForumRow row)
        {
            ForumD d = new ForumD();
            d.Forum_id = row.Forum_id;
            d.Nom = row.Nom;
            d.Url = row.Url;

            return d;
        }
    }
}