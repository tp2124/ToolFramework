using RazorEngine;
using RazorEngine.Templating; // For extension methods.

namespace TP.Services.Format
{
    public class RazorTextFormatter : IFormatTextService
    {
        public string Demo()
        {
            string template = "Hello @Model.Name, welcome to RazorEngine!";
            var result =
                Engine.Razor.RunCompile(template, "templateKey", null, new { Name = "World" });
            result = Engine.Razor.Run("templateKey", null, new { Name = "Max" });
            return result;
        }
    }
}