using Forum.DAL.Data;
using Forum.DAL.Data.Mappeur;
using Forum.myDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Forum.DAL
{
    public class ForumDAL
    {
        SqlConnection myConnection;

        public bool CreateForum(ForumD forum)
        {
            using (ps_FOR_GetForumTableAdapter ForumTable = new ps_FOR_GetForumTableAdapter())
            {
                ForumTable.ps_FOR_CreateForum(forum.Nom, forum.Url);
            }
            return true;
        }

        public bool EditForum(ForumD forum)
        {
            using (ps_FOR_GetForumTableAdapter ForumTable = new ps_FOR_GetForumTableAdapter())
            {
                ForumTable.ps_FOR_UpdateForum(forum.Forum_id, forum.Nom);
            }
            return true;
        }

        public bool DeleteForum(int id)
        {
            using (ps_FOR_GetForumTableAdapter ForumTable = new ps_FOR_GetForumTableAdapter())
            {
                ForumTable.ps_FOR_DeleteForum(id);
            }
            return true;
        }

        public List<ForumD> GetListForum()
        {
            myDataSet.ps_FOR_GetForumDataTable datatable;
            using (ps_FOR_GetForumTableAdapter ForumTable = new ps_FOR_GetForumTableAdapter())
            {
                datatable = ForumTable.ps_FOR_GetListForum();
            }
            return ForumMappeur.ToForumD(datatable).ToList();
        }

        public ForumD GetForum(int id)
        {
            myDataSet.ps_FOR_GetForumDataTable datatable;
            using (ps_FOR_GetForumTableAdapter ForumTable = new ps_FOR_GetForumTableAdapter())
            {
                datatable = ForumTable.ps_FOR_GetForum(id);
            }
            return ForumMappeur.ToForumD(datatable).ElementAt(0);
        }
    }
}