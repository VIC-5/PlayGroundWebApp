using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

namespace PlayGroundWebApp.Utilities
{
    public interface IViewRenderService
    {
        public Task<string> RenderToString<T>(string viewName, T model);
    }

    public class ViewRenderService : IViewRenderService
    {
        private readonly IRazorViewEngine _razorViewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IServiceProvider _serviceProvider;

        private readonly IWebHostEnvironment _hostingEnvironment;

        public ViewRenderService(IRazorViewEngine razorViewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider, IWebHostEnvironment hostingEnvironment)
        {
            _razorViewEngine = razorViewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> RenderToString<T>(string viewName, T model)
        {
            var httpContext = new DefaultHttpContext { RequestServices = _serviceProvider };
            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

            using var sw = new StringWriter();
            var viewResult = _razorViewEngine.FindView(actionContext, viewName, false);

            var vName = "/Views/TrueWebApi/User.cshtml";

            var exeFilePath = GetExecutingFilePath(vName, _hostingEnvironment);
            var viewPath = $"~{vName}";

            var vResult = _razorViewEngine.GetView(exeFilePath, viewPath, false);
            //var viewResult = _razorViewEngine.GetView(exeFilePath, viewPath, false);
            Console.WriteLine(vResult);

            if (viewResult.View == null)
            {
                return string.Empty;
            }

            var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = model
            };

            var viewContext = new ViewContext(
                actionContext,
                viewResult.View,
                viewDictionary,
                new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
                sw,
                new HtmlHelperOptions()
            );

            await viewResult.View.RenderAsync(viewContext);

            return sw.ToString();

            throw new NotImplementedException();
        }

        private string GetExecutingFilePath(string viewName , IWebHostEnvironment hostingEnvironment)
        {
            var contentRootPath = hostingEnvironment.ContentRootPath;
            var executingAssemblyDirectoryAbsolutePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var executingAssemblyDirectoryRelativePath = System.IO.Path.GetRelativePath(contentRootPath, executingAssemblyDirectoryAbsolutePath);
            var executingFilePath = $"{executingAssemblyDirectoryRelativePath.Replace('\\', '/')}{viewName}";

            return executingFilePath;
        }
    }
}