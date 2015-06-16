using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Treinamento.Binders;

namespace Treinamento.App_Start
{
    public class BinderConfig
    {
        public static void Register()
        {
            ModelBinders.Binders.Add(typeof(DateTime), new DateTimeBinder());
        }
    }
}