using TeamSite.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamSite.Helpers
{
        [HtmlTargetElement("div", Attributes = "page-model")]
        public class PagingTagHelper : TagHelper
        {
            private IUrlHelperFactory urlHelperFactory;

            public PagingTagHelper(IUrlHelperFactory urlHelper)
            {
                urlHelperFactory = urlHelper;
            }

            [ViewContext]
            [HtmlAttributeNotBound]
            public ViewContext ViewContext { get; set; }

          
            public PagingInfo PageModel { get; set; }

       
            public string PageAction { get; set; }

            public bool PageClassesEnabled { get; set; }

            public string PageClass { get; set; }

            public string PageClassNormal { get; set; }

            public string PageClassSelected { get; set; }

            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                var urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

                TagBuilder result = new TagBuilder("div");

                for (int i = 1; i <= PageModel.TotalPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(new UrlActionContext() { Action = PageAction, Values = new { productPage = i } });
                    tag.InnerHtml.Append(i.ToString());

                    if (PageClassesEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        string currentClass = i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal;
                        tag.AddCssClass(currentClass);
                    }


                    result.InnerHtml.AppendHtml(tag);
                }

                output.Content.AppendHtml(result.InnerHtml);
            }
        }

    }
