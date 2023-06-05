using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.IO.Abstractions;
using System.Diagnostics;

public class LogActionFilter : ActionFilterAttribute
{
    private readonly string logFilePath;
    private readonly object fileLock = new object();
    private readonly IFileSystem fileSystem;

    public LogActionFilter()
        : this(new FileSystem())
    {
    }

    public LogActionFilter(IFileSystem fileSystem)
    {
        this.logFilePath = @"C:\Users\shai2\OneDrive\Desktop\School\Project&Assignments\PetProject\AmirPetProject\Logging\log.dat";
        this.fileSystem = fileSystem;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        Log("OnActionExecuting", context.RouteData);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        Log("OnActionExecuted", context.RouteData);
    }

    public override void OnResultExecuting(ResultExecutingContext context)
    {
        Log("OnResultExecuting", context.RouteData);
    }

    public override void OnResultExecuted(ResultExecutedContext context)
    {
        Log("OnResultExecuted", context.RouteData);
    }
    
    private void Log(string methodName, Microsoft.AspNetCore.Routing.RouteData routeData)
    {
        var controllerName = routeData.Values["controller"];
        var actionName = routeData.Values["action"];
        var message = $"{DateTime.Now}: {methodName} controller: {controllerName} action: {actionName}";

        try
        {
            lock (fileLock)
            {
                using (StreamWriter writer = fileSystem.File.AppendText(logFilePath))
                {
                    writer.WriteLine(message);
                }

            }
        }
        catch (Exception ex)
        {
            for (int i = 0; i < 10; i++)
            {
                Debug.WriteLine("[ERROR] Log File corrupted, please delete 'log.dat' file to reset Logging.");
            }
        }
    }
}
