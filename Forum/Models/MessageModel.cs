using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.Models
{
    /// <summary>
    /// Message Model
    /// </summary>
    public class MessageModel
    {
        public long Message_id { get; set; }
        public long Topic_id { get; set; }
        public long Utilisateur_id { get; set; }
        public System.DateTime DatePoste { get; set; }
        public string ContenuMessage { get; set; }
        public bool Report { get; set; }
    }
}
