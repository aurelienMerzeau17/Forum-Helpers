using Forum.Business;
using Forum.Business.Data;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logger;

namespace Forum.Controllers
{
    /// <summary>
    /// Available method for categories
    /// </summary>
    public class CategoryController : ApiController
    {

        string urlLogger = "http://loggerasp.azurewebsites.net/";

        /// <summary>
        /// Get an array of all category informations of a forum
        /// </summary>
        /// <param name="IDForum">Forum id</param>
        /// <returns>Array ListCategoryModel</returns>
        [HttpGet]
        [Route("api/CategoryForum/{IDForum}")]
        public List<CategorieModel> GetListCategoryForum(int IDForum)
        {
            try
            {
                CategorieBusiness categorie = new CategorieBusiness();
                return ConvertModel.ToModel(categorie.GetListCategorieForum(IDForum));
            }
            catch(Exception e)
            {
                new LErreur(e, "Forum", "GetListCategoryForum", 5).Save(urlLogger);
                return null;
            }
        }


        /// <summary>
        /// Get a category informations by id
        /// </summary>
        /// <param name="IDCategory">Category id</param>
        [HttpGet]
        [Route("api/Category/{IDCategory}")]
        public CategorieModel GetCategory(int IDCategory)
        {
            try
            {
                CategorieBusiness catbusi = new CategorieBusiness();
                return ConvertModel.ToModel(catbusi.getCategorie(IDCategory));
            }
            catch (Exception e)
            {
                new LErreur(e, "Forum", "GetCategory", 5).Save(urlLogger);
                return null;
            }
        }


        /// <summary>
        /// Get an array of all category informations
        /// </summary>
        /// <returns>Array ListCategoryModel</returns>
        [HttpGet]
        [Route("api/Category")]
        public List<CategorieModel> GetListCategory()
        {
            try
            {
                CategorieBusiness categorie = new CategorieBusiness();
                return ConvertModel.ToModel(categorie.GetListCategorie());
            }
            catch (Exception e)
            {
                new LErreur(e, "Forum", "GetListCategory", 5).Save(urlLogger);
                return null;
            }
        }

        ///// <summary>
        ///// Create a Category with his name and the forum id
        ///// </summary>
        ///// <param name="cat">CategorieModel</param>
        //[HttpPost]
        //[Route("api/Category")]
        //public bool CreateCategory(CategorieModel cat)
        //{
        //    CategorieBusiness catmodel = new CategorieBusiness();
        //    return catmodel.CreateCategorie(ConvertModel.ToBusiness(cat));
        //}

        ///// <summary>
        ///// Edit a category by id
        ///// </summary>
        ///// <param name="cat">CategorieModel</param>
        //[HttpPost]
        //[Route("api/Category/{IDCategory}")]
        //public bool EditCategory(CategorieModel cat)
        //{
        //    CategorieBusiness CategoryM = new CategorieBusiness();
        //    return CategoryM.EditCategorie(ConvertModel.ToBusiness(cat));
        //}

        ///// <summary>
        ///// Delete a category by id
        ///// </summary>
        ///// <param name="IDCategory">category id</param>
        //[HttpDelete]
        //[Route("api/Category/{IDCategory}")]
        //public bool DeleteCategory(int IDCategory)
        //{
        //    CategorieBusiness categorieB = new CategorieBusiness();
        //    return categorieB.DeleteCategorie(IDCategory);
        //}
    }
}
