using Riod.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riod.WebUI.AppCode.Extensions
{
     static  public  partial class Extension
    {
        static public string GetCategoriesRaw(this List<Category> categories)
        {
            if (categories == null || !categories.Any())
          
                return "";
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul class='widget-body filter-items search-ul'>");
            foreach (var category in categories) {
                FillCategoriesRaw(category);
                    }
                
 
            sb.Append("</ul>");
            return  sb.ToString();
            void FillCategoriesRaw(Category category)
            {
                sb.Append($"<li><a href='#'>{category.Name}</a>");

                if (category.Children != null && category.Children.Any())
                {
                    sb.Append("<ul>");
                    foreach (var item in category.Children)
                 
                        FillCategoriesRaw(item);
                    
                    sb.Append("</ul>");
                   
                }
                sb.Append("</li>");
            }
        }
        static public IEnumerable<Category>  GetCategoriesChildren(this Category parent) {

            if(parent.ParentId!=null)
            yield return parent;
            foreach (var child in parent.Children.SelectMany(c=>c.GetCategoriesChildren()))
            {
                yield return child;
            }
            
        }
    }
}
