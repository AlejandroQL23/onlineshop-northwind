using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace ShopOnline.Northwind.MvcWebUI.TagHelpers
{
    [HtmlTargetElement("product-list-pager")]
    public class ProductPagingTagHelper : TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }

        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }

        [HtmlAttributeName("current-category")]
        public int CurrentCategory { get; set; }

        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            StringBuilder builder = new StringBuilder();

            //1 sayfadan fazla veri varsa pagination
            if (PageCount > 1)
            {
                builder.Append("<ul class='pagination justify-content-end'>");

                //Previous Button
                builder.AppendFormat("<li class='page-item  {0}'>", (CurrentPage - 1) <= 0 ? "disabled" : "");
                builder.AppendFormat("<a class='page-link' href='/product/index?page={0}&category={1}'>Önceki</a>", (CurrentPage - 1), CurrentCategory);
                builder.Append("</li>");

                //Buttons
                for (int page = 1; page < PageCount; page++)
                {
                    builder.AppendFormat("<li class='page-item {0}'>", page == CurrentPage ? "active" : "");
                    builder.AppendFormat("<a class='page-link' href='/product/index?page={0}&category={1}'>{2}</a>", page, CurrentCategory, page);
                    builder.Append("</li>");
                }

                //Next Button
                builder.AppendFormat("<li class='page-item {0}'>", (CurrentPage + 1) >= PageCount ? "disabled" : "");
                builder.AppendFormat("<a class='page-link' href='/product/index?page={0}&category={1}'>Sonraki</a>", (CurrentPage + 1), CurrentCategory);
                builder.Append("</li>");
            }

            output.Content.SetHtmlContent(builder.ToString());

            base.Process(context, output);
        }
    }
}
