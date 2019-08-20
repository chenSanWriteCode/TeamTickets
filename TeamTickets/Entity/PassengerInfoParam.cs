using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTickets.Entity
{
    public class PassengerInfoParam
    {
        public string deptId { get; set; }

        public string account { get; set; }
        public List<PassengerInfo> groupPassengerInfo { get; set; }
    }

    public class PassengerInfo
    {
        public string cardName { get; set; }
        public string cardNo { get; set; }
    }
}
