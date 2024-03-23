using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperSamples.TagHelpers
{
    [HtmlTargetElement(Attributes = "zm-tbl-attribute")]
    public class TableTagHelper : TagHelper
    {
        public string ZmTblAttribute { get; set; } = "primary";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("class", $"table table-bordered table-striped table-{ZmTblAttribute}");
            output.PostContent.Append("this is post content");
        }
    }
}
