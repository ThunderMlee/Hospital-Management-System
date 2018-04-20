using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalMVC.HTMLHelpers
{
    public static class CustomTags
    {
         public static IHtmlString Image(this HtmlHelper helper, string src, string alt)
        {
            String role = SessionStateAttribute[]
            if ((String)Session["Role"] == "")
            TagBuilder tb = new TagBuilder("img");
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            tb.Attributes.Add("alt", alt);
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));

        }
    }
}