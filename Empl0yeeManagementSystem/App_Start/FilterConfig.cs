﻿using System.Web;
using System.Web.Mvc;

namespace Empl0yeeManagementSystem
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
