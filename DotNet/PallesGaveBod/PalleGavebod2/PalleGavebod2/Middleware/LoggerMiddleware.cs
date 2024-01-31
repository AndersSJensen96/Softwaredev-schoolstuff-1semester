using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using PalleGavebod2.Models;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Options;

namespace PalleGavebod2.Middleware
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class LoggerMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly MyFileLoggerOptions _options;

		public LoggerMiddleware(RequestDelegate next, IOptions<MyFileLoggerOptions> options)
		{
			_options = options.Value;
			_next = next;
		}


		public async Task Invoke(HttpContext context)
		{
			var request = context.Request;
			var requestLogMessage = $"REQUEST:\n{request.Method} - {request.Path.Value}{request.QueryString}";
			requestLogMessage += $"\nContentType: {request.ContentType ?? "Not specified"}";
			requestLogMessage += $"\nHost: {request.Host}";
			File.AppendAllText(_options.FileName, $"{DateTime.Now.ToString("s")}\n{requestLogMessage}");

			await _next(context);

			var response = context.Response;
			var responseLogMessage = $"\nRESPONSE:\nStatus Code: {response.StatusCode}";
			File.AppendAllText(_options.FileName, $"{responseLogMessage}\n\n");


		}
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class LoggerMiddlewareExtensions
	{
		public static IApplicationBuilder UseLoggerMiddleware(this IApplicationBuilder builder, Action<MyFileLoggerOptions> action)
		{
			/*Action delegate type og filelogger er lavet så man kan bruge lambda udtrykket i startup. Derudover skal du bruger options patteren (kan ikke huske navnet) som bruger microsoft.extension.options.
			 HUSK at injekte din filelogger i constructoren som en Ioptions.*/
			MyFileLoggerOptions FileLogger = new MyFileLoggerOptions();
			action(FileLogger);
			return builder.UseMiddleware<LoggerMiddleware>(Options.Create(FileLogger));
		}
	}
}
