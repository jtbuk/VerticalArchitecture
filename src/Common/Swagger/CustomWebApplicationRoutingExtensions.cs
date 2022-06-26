using System.Net;

namespace Jtbuk.VerticalArchitecture.Common.Swagger;

public static class CustomWebApplicationRoutingExtensions
{
    public static RouteHandlerBuilder Get(
        this WebApplication builder,
        string route,
        Delegate action,
        string tag)
    {
        return builder
            .MapGet(route, action)
            .WithTags(tag)
            .Produces((int)HttpStatusCode.OK)
            .Produces((int)HttpStatusCode.NotFound, typeof(CustomError));        
    }

    public static RouteHandlerBuilder Post(
        this WebApplication builder,
        string route,
        Delegate action,
        string tag)
    {
        var routeHandlerBuilder = builder
            .MapPost(route, action)
            .WithTags(tag);            
        
        return routeHandlerBuilder;
    }

    public static RouteHandlerBuilder Put(
        this WebApplication builder,
        string route,
        Delegate action,
        string tag)
    {
        return builder
            .MapPut(route, action)
            .WithTags(tag)
            .Produces((int)HttpStatusCode.NoContent)
            .Produces((int)HttpStatusCode.NotFound, typeof(CustomError));
    }
}
