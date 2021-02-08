using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodyna.Models.Domain
{
    public class Vesti
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public DateTime? CreatedTimeStamp { get; set; }
    }
}