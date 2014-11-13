using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Forum.DAL
{
    public class Employee
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string NomComplet { get; set; }
        public string Adresse { get; set; }
        public int Contact { get; set; }

        public override string ToString()
        {
            return "Nom: " + Nom + Environment.NewLine +
                   "Prénom: " + Prenom + Environment.NewLine +
                   "Nom Complet: " + NomComplet + Environment.NewLine +
                   "Adresse: " + Adresse + Environment.NewLine +
                   "Contact: " + Contact + Environment.NewLine;
        }
       
    }
    
 
}
