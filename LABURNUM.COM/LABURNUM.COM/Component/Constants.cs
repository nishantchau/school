﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class Constants
    {
        public static class URL
        {
            public static string WEBAPIURL = System.Configuration.ConfigurationManager.AppSettings["WEBAPIURL"];
            public static string WEBSITEURL = System.Configuration.ConfigurationManager.AppSettings["WEBSITEURL"];
            public static string WEBSITEURLWITHOUTSLASH = System.Configuration.ConfigurationManager.AppSettings["WEBSITEURLWITHOUTSLASH"];
        }

        public static class APIACCESS
        {
            public static string APIUSERNAME = System.Configuration.ConfigurationManager.AppSettings["APIUSERNAME"];
            public static string APIPASSWORD = System.Configuration.ConfigurationManager.AppSettings["APIPASSWORD"];
            public static int HTTPTIME = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["HTTPTIME"]);
        }
        public static class ERRORMESSAGES
        {
            public static string NO_RECORD_FOUND = "No Record Found.";
            public static string MORE_THAN_ONE_RECORDFOUND = "More Than One Record Found.";
        }

        public static class KEYS
        {
            public static string SALTKEY = System.Configuration.ConfigurationManager.AppSettings["SALTKEY"];
            public static string SHAREDKEY = System.Configuration.ConfigurationManager.AppSettings["SHAREDKEY"];
        }
    }
}