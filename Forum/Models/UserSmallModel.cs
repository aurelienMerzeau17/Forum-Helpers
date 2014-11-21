using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class UserSmallModel
    {
        public int Utilisateur_Id { get; set; }
        public string Pseudo { get; set; }
        public string PhotoChemin { get; set; }
    }
}