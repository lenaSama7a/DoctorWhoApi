using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Entities
{
    public class ViewEpisodes
    {
        public string AuthorName { get; set; }
        public string DoctorName { get; set; }
        public string Companions { get; set; }
        public string Enemies { get; set; }
    }
}
