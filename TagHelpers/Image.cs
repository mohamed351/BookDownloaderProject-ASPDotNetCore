using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDownloader.TagHelpers
{
    public class Image: TagHelperComponent
    {
        public string ImageName { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml($"<img src='/images/{ImageName}'/> ");

        }
    }
}
