using Forum.Business.Data;
using Forum.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Business
{
    public class CategorieBusiness
    {

        public CategorieB getCategorie(int id)
        {
            CategorieDAL categorie = new CategorieDAL();
            return ConvertBusiness.ToBusiness(categorie.GetCategorie(id));
        }

        public List<CategorieB> GetListCategorie()
        {
            CategorieDAL categorie = new CategorieDAL();
            return ConvertBusiness.ToBusiness(categorie.GetListCategorie());
        }

        public List<CategorieB> GetListCategorieForum(int forum_id)
        {
            CategorieDAL categorie = new CategorieDAL();
            return ConvertBusiness.ToBusiness(categorie.GetListCategorieByForum(forum_id));
        }

        public bool CreateCategorie(CategorieB cat)
        {
            CategorieDAL categorie = new CategorieDAL();
            return categorie.CreateCategorie(ConvertBusiness.ToDAL(cat));
        }

        public bool EditCategorie(CategorieB cat)
        {
            CategorieDAL categorie = new CategorieDAL();
            return categorie.EditCategorie(ConvertBusiness.ToDAL(cat));
        }

        public bool DeleteCategorie(int id)
        {
            TopicBusiness top = new TopicBusiness();
            List<TopicB> listTopB = top.GetTopicByCategory(Convert.ToInt32(id));

            foreach (TopicB t in listTopB)
            {
                MessageBusiness mes = new MessageBusiness();
                List<MessageB> listMesB = mes.GetListTopicMessage(Convert.ToInt32(t.Topic_id));

                foreach (MessageB m in listMesB)
                {
                    mes.DeleteMessage(Convert.ToInt32(m.Message_id));
                }
                top.DeleteTopic(Convert.ToInt32(t.Topic_id));
            }

            CategorieDAL categorie = new CategorieDAL();
            return categorie.DeleteCategorie(id);
        }
    }
}

