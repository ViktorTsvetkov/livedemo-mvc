using System;
using System.Linq;
using System.Threading;
using System.Web;

namespace LiveDemo_MVC.HttpModules
{
    public class CultureModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += this.Context_BeginRequest;
        }

        public void Dispose()
        {
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            var urlParts = HttpContext.Current.Request.Url.AbsoluteUri.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (urlParts.Count() > 2)
            {
                string lang = urlParts[2];

                if (lang == "bg")
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("bg");
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("bg");
                }
            }
        }
    }
}