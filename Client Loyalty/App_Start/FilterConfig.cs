﻿using System.Web;
using System.Web.Mvc;

namespace Client_Loyalty
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
