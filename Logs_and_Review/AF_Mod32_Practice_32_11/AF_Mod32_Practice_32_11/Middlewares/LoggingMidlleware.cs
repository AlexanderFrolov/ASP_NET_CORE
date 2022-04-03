namespace AF_Mod32_Practice_32_11.Middlewares
{
    public class LoggingMidlleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        ///  Middleware component must have a constructor that accepts RequestDelegate
        /// </summary>
        public LoggingMidlleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        ///  Invoke or InvokeAsync must be implemented
        /// </summary>
        public async Task InvokeAsync(HttpContext context, IWebHostEnvironment env)
        {
            string logMessage = CreateLogMessage(context);

            LogConsole(logMessage);

            await LogFile(context, logMessage, env);

            // send request further by pipeline
            await _next.Invoke(context);
        }

        /// <summary>
        ///   create string to write to log
        /// </summary>
        private string CreateLogMessage(HttpContext context)
        {
            return $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path} " +
            $"{Environment.NewLine}";
        }

        /// <summary>
        /// logging to console
        /// </summary>
        private void LogConsole(string logMessage)
        {
            Console.Write(logMessage);
        }

        /// <summary>
        ///  write to log file 
        /// </summary>    
        private async Task LogFile(HttpContext context, string logMessage, IWebHostEnvironment env)
        {
            // Path to the log (again, we use the IWebHostEnvironment properties)
            string logFilePath = Path.Combine(env.ContentRootPath, "Logs", "RequestLog.txt");

            // use asynchronous write to file
            await File.AppendAllTextAsync(logFilePath, logMessage);
        }
    }
}
