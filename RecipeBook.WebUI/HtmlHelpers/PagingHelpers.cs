using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using RecipeBook.WebUI.Models;

namespace RecipeBook.WebUI.HtmlHelpers
{
    public static class HtmlExtensions
    {
        
        public static MvcHtmlString ShowButton(this HtmlHelper html, string name, string function)
        {
            
            var isAdmin = html.ViewContext.HttpContext.User.Identity.IsAuthenticated;
            if (isAdmin)
            {
                return html.ActionLink(name, "Index", "Admin", function, new { @class = "text-styling" });
            }
            return new MvcHtmlString(string.Empty);
        }
    }
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int,string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for(int i = 1; i<= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();

                if(i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }

                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

    }
}