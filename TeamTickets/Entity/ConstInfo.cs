using System;
using System.Configuration;

namespace TeamTickets.Entity
{
    public class ConstInfo
    {
        public static readonly string URL_Base_Phone = ConfigurationManager.AppSettings["URL_Phone"];
        public const string URL_Phone = "/pckg/apiCtrl/ifAppUser.html";

        public static readonly string URL_Base_Save= ConfigurationManager.AppSettings["URL_Save"];
        public const string URL_Save = "/pckg/apiCtrl/ifAppUser.html";

        public static readonly string SSL_Name = ConfigurationManager.AppSettings["SSL_Name"];

        public static readonly string comPort= ConfigurationManager.AppSettings["Com_Port"];

        //public static readonly string affectDay= ConfigurationManager.AppSettings["Affect_Day"];

        public static readonly string harbour= ConfigurationManager.AppSettings["Area"];

        public const string TicketID_Path = "TicketID.xml";

    }
}
