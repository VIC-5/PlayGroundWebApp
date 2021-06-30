using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PlayGroundWebApp.Utilities.TagHelpers
{
    public class DoubleTagHelper : TagHelper
    {
        public string Id { get; set; }
        public string Class { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("id", Id);

            var content = await output.GetChildContentAsync();
            var inner = GetInnerContent(Class, content.GetContent());

            output.Content.SetHtmlContent(inner);
        }

        private string GetInnerContent(string innerClass, string innerValue)
        {
            var div = new TagBuilder("div");
            div.MergeAttribute("class", innerClass);
            div.InnerHtml.Append(innerValue);

            using var writer = new StringWriter();
            div.WriteTo(writer, HtmlEncoder.Create(new TextEncoderSettings(UnicodeRanges.All)));

            return writer.ToString();
        }
    }
}