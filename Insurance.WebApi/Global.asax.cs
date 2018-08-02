﻿using System.Web;
using System.Web.Http;
using Insurance.Database.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Insurance.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(FilterConfig.Configure);

            System.Data.Entity.Database.SetInitializer(new Initializer());

            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
