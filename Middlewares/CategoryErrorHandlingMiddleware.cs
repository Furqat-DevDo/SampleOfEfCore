﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace EfCore.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CategoryErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public CategoryErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CategoryErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCategoryErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CategoryErrorHandlingMiddleware>();
        }
    }
}
