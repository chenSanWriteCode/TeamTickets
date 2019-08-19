using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTickets.Entity
{
    public class TicketCode
    {
        public string Id { get; set; }
        public string Code { get; set; } = "";
        public int TeamCount { get; set; }
        public int HalfCount { get; set; }
        public int GuideCount { get; set; }
        public int BabyCount { get; set; }
        public int AffectDay { get; set; }
        public string AffectStr { get; set; }//{ get { return DateTime.Now.ToString("yyyy-MM-dd") + "    至    " + DateTime.Now.AddDays(this.AffectDay).ToString("yyyy-MM-dd"); } }
    }
}
